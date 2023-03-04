use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

create table FtsIncrementTable
(
	IdTable smallint,
    TableName varchar(32),
    constraint Pk_FtsIncrementTable primary key (IdTable)
);

create table FtsIncrementControllerTable
(
	ControllerTableName varchar(32),
    constraint Pk_FtsIncrementControllerTable primary key (ControllerTableName)
);

create table FtsIncrementByDomain
(
	IdTable smallint,
    IdDomain smallint,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByDomain primary key (IdTable, IdDomain)
);

create table FtsIncrementByDomainMaster
(
	IdTable smallint,
    IdDomain smallint,
    IdMaster integer,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByDomainMaster primary key (IdTable, IdDomain, IdMaster)
);

create table FtsIncrementByBranch
(
	IdTable smallint,
    IdDomain smallint,
    IdBranch smallint,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByBranch primary key (IdTable, IdDomain, IdBranch)
);

create table FtsIncrementByBranchMaster
(
	IdTable smallint,
    IdDomain smallint,
    IdBranch smallint,
    IdMaster integer,
    IdLastIncrement integer,
    constraint Pk_FtsIncrementByBranchMaster primary key (IdTable, IdDomain, IdBranch, IdMaster)
);



-- Constraints section ----------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

alter table FtsIncrementTable 
	add constraint Uk_FtsIncrementTable1 unique (TableName);
    
alter table FtsIncrementByDomain 
	add constraint Fk_FtsIncrementByDomain1 foreign key (IdTable) references FtsIncrementTable (IdTable);
alter table FtsIncrementByDomain 
    add constraint Fk_FtsIncrementByDomain2 foreign key (IdDomain) references FwkDomain (IdDomain);
    
alter table FtsIncrementByDomainMaster 
	add constraint Fk_FtsIncrementByDomainMaster1 foreign key (IdTable) references FtsIncrementTable (IdTable);
alter table FtsIncrementByDomainMaster 
    add constraint Fk_FtsIncrementByDomainMaster2 foreign key (IdDomain) references FwkDomain (IdDomain);
    
alter table FtsIncrementByBranch 
	add constraint Fk_FtsIncrementByBranch1 foreign key (IdTable) references FtsIncrementTable (IdTable);
alter table FtsIncrementByBranch 
    add constraint Fk_FtsIncrementByBranch2 foreign key (IdDomain, IdBranch) references FwkBranch (IdDomain, IdBranch);
    
alter table FtsIncrementByBranchMaster 
	add constraint Fk_FtsIncrementByBranchMaster1 foreign key (IdTable) references FtsIncrementTable (IdTable);
alter table FtsIncrementByBranchMaster 
    add constraint Fk_FtsIncrementByBranchMaster2 foreign key (IdDomain, IdBranch) references FwkBranch (IdDomain, IdBranch);



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

-- Ark.Vinke.Facilities
insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Vinke.Facilities', 'Ark Vinke Facilities');

-- Ark.Vinke.Facilities.Core.Server.FtsIncrementServer
insert into FwkFeature (IdDomain, CodModule, CodProject, CodFeature, CodModuleBase, CodProjectBase, CodFeatureBase) values (1, 'Ark.Vinke.Facilities', 'Core.Server', 'FtsIncrementServer', 'Ark.Vinke.Framework', 'Core.Server', 'FwkServer');
insert into FwkFeatureAction (IdDomain, CodModule, CodProject, CodFeature, CodAction, Description) values (1, 'Ark.Vinke.Facilities', 'Core.Server', 'FtsIncrementServer', 'ValidateNext', 'Validate generate next ids');
insert into FwkFeatureAction (IdDomain, CodModule, CodProject, CodFeature, CodAction, Description) values (1, 'Ark.Vinke.Facilities', 'Core.Server', 'FtsIncrementServer', 'Next', 'Generate next ids');

insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByDomain');
insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByDomainMaster');
insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByBranch');
insert into FtsIncrementControllerTable (ControllerTableName) values ('FtsIncrementByBranchMaster');
