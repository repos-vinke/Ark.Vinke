use Ark;



-- Create tables section --------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

create table SysAutomationFeature
(
	IdDomain smallint,
    IdFeature smallint,
    CodModule varchar(32),
    CodProject varchar(32),
    CodFeature varchar(32),
    IdUser integer,
    Culture char(4),
    Enabled char(1),
    History char(1),
    Request text,
    constraint Pk_SysAutomationFeature primary key (IdDomain, IdFeature)
);

create table SysAutomationHost
(
	IdDomain smallint,
    IdHost smallint,
    Identifier varchar(64),
    Alias varchar(32),
    Enabled char(1),
    constraint Pk_SysAutomationHost primary key (IdDomain, IdHost)
);

create table SysAutomationWorker
(
	IdDomain smallint,
    IdHost smallint,
    IdWorker smallint,
    Guid varchar(32),
    Alias varchar(32),
    Enabled char(1),
    Count integer,
    Workload decimal,
    Status char(1),
    constraint Pk_SysAutomationWorker primary key (IdDomain, IdHost, IdWorker)
);

create table SysAutomationReservation
(
	IdDomain smallint,
    IdHost smallint,
    IdWorker smallint,
    IdFeature smallint,
    Dedicated char(1),
    Enabled char(1),
    constraint Pk_SysAutomationReservation primary key (IdDomain, IdHost, IdWorker)
);

create table SysAutomationScheduler
(
	IdDomain smallint,
    IdFeature smallint,
    IntervalTime integer,
    LastExecution datetime,
    NextExecution datetime,
    constraint Pk_SysAutomationScheduler primary key (IdDomain, IdFeature)
);

create table SysAutomationExecution
(
	IdDomain smallint,
    IdFeature smallint,
    NextExecution datetime,
    IdHost smallint,
    constraint Pk_SysAutomationExecution primary key (IdDomain, IdFeature, NextExecution)
);

create table SysAutomationHistory
(
	IdDomain smallint,
    IdFeature smallint,
    LastExecution datetime,
    IdHost smallint,
    StartedAt datetime,
    FinishedAt datetime,
    Status char(1),
    Response text,
    constraint Pk_SysAutomationHistory primary key (IdDomain, IdFeature, LastExecution)
);



-- Constraints section ----------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

alter table SysAutomationFeature 
	add constraint Fk_SysAutomationFeature1 foreign key (IdDomain, CodModule, CodProject, CodFeature) references FwkFeature (IdDomain, CodModule, CodProject, CodFeature);
alter table SysAutomationFeature 
    add constraint Fk_SysAutomationFeature2 foreign key (IdDomain, IdUser) references FwkUser (IdDomain, IdUser);
    
alter table SysAutomationHost 
	add constraint Fk_SysAutomationHost1 foreign key (IdDomain) references FwkDomain (IdDomain);
alter table SysAutomationHost 
    add constraint Uk_SysAutomationHost1 unique (Identifier);
    
alter table SysAutomationWorker 
	add constraint Fk_SysAutomationWorker1 foreign key (IdDomain, IdHost) references SysAutomationHost (IdDomain, IdHost);
alter table SysAutomationWorker 
    add constraint Uk_SysAutomationWorker1 unique (Guid);
    
alter table SysAutomationReservation 
	add constraint Fk_SysAutomationReservation1 foreign key (IdDomain, IdHost, IdWorker) references SysAutomationWorker (IdDomain, IdHost, IdWorker);
alter table SysAutomationReservation 
    add constraint Fk_SysAutomationReservation2 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature);
    
alter table SysAutomationScheduler 
    add constraint Fk_SysAutomationScheduler1 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature);
    
alter table SysAutomationExecution 
    add constraint Fk_SysAutomationExecution1 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature);
alter table SysAutomationExecution 
    add constraint Fk_SysAutomationExecution2 foreign key (IdDomain, IdHost) references SysAutomationHost (IdDomain, IdHost);
    
alter table SysAutomationHistory 
    add constraint Fk_SysAutomationHistory1 foreign key (IdDomain, IdFeature) references SysAutomationFeature (IdDomain, IdFeature);
alter table SysAutomationHistory 
    add constraint Fk_SysAutomationHistory2 foreign key (IdDomain, IdHost) references SysAutomationHost (IdDomain, IdHost);



-- Initial data section ---------------------------------------------------------------------------------------------------------------------
-- ------------------------------------------------------------------------------------------------------------------------------------------

insert into FwkModule (IdDomain, CodModule, Description) values (1, 'Ark.Vinke.System', 'Ark Vinke System');
