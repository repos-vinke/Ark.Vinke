﻿// SysAuthenticationService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

using Lazy.Vinke;
using Lazy.Vinke.Json;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Service;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Framework.Core.IService;
using Ark.Vinke.Framework.Core.Service;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;
using Ark.Vinke.Facilities.Core.IService;
using Ark.Vinke.Facilities.Core.Servant;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IPlugin;
using Ark.Vinke.System.Core.IService;

namespace Ark.Vinke.System.Core.Service
{
    public class SysAuthenticationService : FwkService, ISysAuthenticationService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationService(FwkEnvironment environment)
            : base(environment)
        {
        }

        public SysAuthenticationService(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="authenticationDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysAuthenticationDataResponse Authenticate(SysAuthenticationDataRequest authenticationDataRequest)
        {
            try
            {
                this.Operation = "Authenticate";

                SysAuthenticationDataResponse authenticationDataResponse = new SysAuthenticationDataResponse();

                // At this service the inherit database object will always be null

                InternalAuthenticate(authenticationDataRequest, authenticationDataResponse);

                // At this service the inherit database object will always be null

                return authenticationDataResponse;
            }
            catch
            {
                // At this service the inherit database object will always be null

                throw;
            }
        }

        /// <summary>
        /// Internal service authentication
        /// </summary>
        /// <param name="authenticationDataRequest">The request data</param>
        /// <param name="authenticationDataResponse">The response data</param>
        protected void InternalAuthenticate(SysAuthenticationDataRequest authenticationDataRequest, SysAuthenticationDataResponse authenticationDataResponse)
        {
            PerformAuthenticate(authenticationDataRequest, authenticationDataResponse);
        }

        /// <summary>
        /// Perform service authentication
        /// </summary>
        /// <param name="authenticationDataRequest">The request data</param>
        /// <param name="authenticationDataResponse">The response data</param>
        protected void PerformAuthenticate(SysAuthenticationDataRequest authenticationDataRequest, SysAuthenticationDataResponse authenticationDataResponse)
        {
            BeforePerformAuthenticate(authenticationDataRequest, authenticationDataResponse);

            #region BeforeAuthenticate

            if (this.IPlugins != null)
            {
                foreach (ISysAuthenticationPlugin iAuthenticationPlugin in this.IPlugins)
                    iAuthenticationPlugin.AuthenticatePluginBeforeEventHandler?.Invoke(this, new SysAuthenticationPluginBeforeEventArgs(authenticationDataRequest, authenticationDataResponse));
            }

            #endregion BeforeAuthenticate

            OnAuthenticate(authenticationDataRequest, authenticationDataResponse);

            #region AfterAuthenticate

            if (this.IPlugins != null)
            {
                foreach (ISysAuthenticationPlugin iAuthenticationPlugin in this.IPlugins)
                    iAuthenticationPlugin.AuthenticatePluginAfterEventHandler?.Invoke(this, new SysAuthenticationPluginAfterEventArgs(authenticationDataRequest, authenticationDataResponse));
            }

            #endregion AfterAuthenticate

            AfterPerformAuthenticate(authenticationDataRequest, authenticationDataResponse);
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="authenticationDataRequest">The request data</param>
        /// <param name="authenticationDataResponse">The response data</param>
        protected virtual void OnAuthenticate(SysAuthenticationDataRequest authenticationDataRequest, SysAuthenticationDataResponse authenticationDataResponse)
        {
            authenticationDataResponse.Content.IdDomain = -1;
            authenticationDataResponse.Content.IdUser = -1;

            if (authenticationDataRequest.Content.Token != null)
            {
                Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary = DecryptTokenJWT(authenticationDataRequest.Content.Token);
                Dictionary<String, String> publicPayloadDictionary = tuplePayloadDictionary.Item1;
                Dictionary<String, String> privatePayloadDictionary = tuplePayloadDictionary.Item2;

                authenticationDataResponse.Content.DatabaseAlias = privatePayloadDictionary["DatabaseAlias"];
                authenticationDataResponse.Content.IdDomain = LazyConvert.ToInt32(privatePayloadDictionary["IdDomain"]);
                authenticationDataResponse.Content.IdUser = LazyConvert.ToInt32(privatePayloadDictionary["IdUser"]);
            }
            else if (String.IsNullOrEmpty(authenticationDataRequest.Content.DomainCode) == false && String.IsNullOrEmpty(authenticationDataRequest.Content.Username) == false && String.IsNullOrEmpty(authenticationDataRequest.Content.Password) == false)
            {
                #region Authenticate on database

                this.Database.OpenConnection();

                String sql = @"
                    select 
	                    FwkDomain.IdDomain, 
                        FwkUser.IdUser, 
                        FwkUser.Password, 
                        FwkUser.DisplayName 
                    from FwkDomain 
	                    inner join FwkUser 
		                    on FwkDomain.IdDomain = FwkUser.IdDomain 
                    where FwkDomain.CodDomain = :CodDomain 
	                    and FwkUser.Username = :Username ";

                DataTable dataTableUser = this.Database.QueryTable(sql, "FwkUser",
                    new Object[] { authenticationDataRequest.Content.DomainCode, authenticationDataRequest.Content.Username },
                    new String[] { "CodDomain", "Username" });

                if (dataTableUser.Rows.Count > 0)
                {
                    String hashedPassword = LazySecurity.Hash.SHA384.Generate(authenticationDataRequest.Content.Password);

                    if (LazyConvert.ToString(dataTableUser.Rows[0]["Password"]) == hashedPassword)
                    {
                        Dictionary<String, String> publicPayloadDictionary = new Dictionary<String, String>();
                        Dictionary<String, String> privatePayloadDictionary = new Dictionary<String, String>();
                        Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary =
                            new Tuple<Dictionary<String, String>, Dictionary<String, String>>(publicPayloadDictionary, privatePayloadDictionary);

                        publicPayloadDictionary.Add("User", LazyConvert.ToString(dataTableUser.Rows[0]["DisplayName"]));
                        privatePayloadDictionary.Add("DatabaseAlias", authenticationDataRequest.Content.DatabaseAlias);
                        privatePayloadDictionary.Add("IdDomain", LazyConvert.ToString(dataTableUser.Rows[0]["IdDomain"]));
                        privatePayloadDictionary.Add("IdUser", LazyConvert.ToString(dataTableUser.Rows[0]["IdUser"]));

                        authenticationDataResponse.Content.IdDomain = LazyConvert.ToInt32(dataTableUser.Rows[0]["IdDomain"]);
                        authenticationDataResponse.Content.IdUser = LazyConvert.ToInt32(dataTableUser.Rows[0]["IdUser"]);
                        authenticationDataResponse.Content.Token = EncryptTokenJWT(tuplePayloadDictionary);
                    }
                }

                this.Database.CloseConnection();

                #endregion Authenticate on database
            }
        }

        /// <summary>
        /// Before perform service authentication
        /// </summary>
        /// <param name="authenticationDataRequest">The request data</param>
        /// <param name="authenticationDataResponse">The response data</param>
        private void BeforePerformAuthenticate(SysAuthenticationDataRequest authenticationDataRequest, SysAuthenticationDataResponse authenticationDataResponse)
        {
        }

        /// <summary>
        /// After perform service authentication
        /// </summary>
        /// <param name="authenticationDataRequest">The request data</param>
        /// <param name="authenticationDataResponse">The response data</param>
        private void AfterPerformAuthenticate(SysAuthenticationDataRequest authenticationDataRequest, SysAuthenticationDataResponse authenticationDataResponse)
        {
        }

        /// <summary>
        /// Decrypt from JWT Token
        /// </summary>
        /// <param name="token">The token to be decrypted</param>
        /// <returns>The payload dictionaries tuple</returns>
        private Tuple<Dictionary<String, String>, Dictionary<String, String>> DecryptTokenJWT(String token)
        {
            ValidateSecrets();

            String secretKey = LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretKey"].Text;
            String secretVector = LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretVector"].Text;

            Byte[] keyArray = Encoding.ASCII.GetBytes(secretKey);

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters();
            tokenValidationParameters.ValidateIssuerSigningKey = true;
            tokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(keyArray);
            tokenValidationParameters.ValidateIssuer = false;
            tokenValidationParameters.ValidateAudience = false;
            tokenValidationParameters.ClockSkew = TimeSpan.Zero;

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)validatedToken;

            String publicPayload = jwtSecurityToken.Payload["public"].ToString();
            String privatePayload = jwtSecurityToken.Payload["private"].ToString();
            privatePayload = LazySecurity.Cryptography.Aes.Decrypt(privatePayload, secretKey, secretVector);

            Dictionary<String, String> publicPayloadDictionary = new Dictionary<String, String>();
            Dictionary<String, String> privatePayloadDictionary = new Dictionary<String, String>();
            Tuple<Dictionary<String, String>, Dictionary<String, String>> tuplePayloadDictionary =
                new Tuple<Dictionary<String, String>, Dictionary<String, String>>(publicPayloadDictionary, privatePayloadDictionary);

            String[] publicPayloadArray = publicPayload.Split(';');
            foreach (String publicPayloadPair in publicPayloadArray)
            {
                String[] keyValue = publicPayloadPair.Split(':');
                publicPayloadDictionary.Add(keyValue[0], keyValue[1]);
            }

            String[] privatePayloadArray = privatePayload.Split(';');
            foreach (String privatePayloadPair in privatePayloadArray)
            {
                String[] keyValue = privatePayloadPair.Split(':');
                privatePayloadDictionary.Add(keyValue[0], keyValue[1]);
            }

            return tuplePayloadDictionary;
        }

        /// <summary>
        /// Encrypt to JWT token
        /// </summary>
        /// <param name="payloadDictionariesTuple">The payload dictionaries tuple</param>
        /// <returns>The encrypted token</returns>
        private String EncryptTokenJWT(Tuple<Dictionary<String, String>, Dictionary<String, String>> payloadDictionariesTuple)
        {
            ValidateSecrets();

            String secretKey = LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretKey"].Text;
            String secretVector = LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretVector"].Text;

            String publicPayload = String.Empty;
            String privatePayload = String.Empty;

            #region Generate public payload

            foreach (KeyValuePair<String, String> publicPayloadPair in payloadDictionariesTuple.Item1)
                publicPayload += publicPayloadPair.Key + ":" + publicPayloadPair.Value + ";";

            if (publicPayload.Length > 0)
                publicPayload = publicPayload.Remove(publicPayload.Length - 1, 1);

            #endregion Generate public payload

            #region Generate private payload

            foreach (KeyValuePair<String, String> privatePayloadPair in payloadDictionariesTuple.Item2)
                privatePayload += privatePayloadPair.Key + ":" + privatePayloadPair.Value + ";";

            if (privatePayload.Length > 0)
                privatePayload = privatePayload.Remove(privatePayload.Length - 1, 1);

            privatePayload = LazySecurity.Cryptography.Aes.Encrypt(privatePayload, secretKey, secretVector);

            #endregion Generate private payload

            Byte[] keyArray = Encoding.ASCII.GetBytes(secretKey);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(keyArray);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Subject = new ClaimsIdentity(new[] { new Claim("public", publicPayload), new Claim("private", privatePayload) });
            securityTokenDescriptor.NotBefore = DateTime.Now;
            securityTokenDescriptor.Expires = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// Validate secrets used for encryption and decryption
        /// </summary>
        private void ValidateSecrets()
        {
            if (String.IsNullOrEmpty(LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretKey"].Text) == true ||
                String.IsNullOrEmpty(LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretVector"].Text) == true)
            {
                LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretKey"].Text = Guid.NewGuid().ToString().Replace("-", String.Empty);
                LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Secrets"]["SecretVector"].Text = Guid.NewGuid().ToString().Replace("-", String.Empty).Substring(0, 16);

                LibConfigurationService.Save();
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
