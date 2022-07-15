CREATE TABLE Producer
(
ProducerId int IDENTITY(1,1) NOT NULL,
ProducerName varchar(500) NOT NULL,
Bio nvarchar(max) NULL,
Company varchar(500) NOT NULL,
DateOfBirth date NOT NULL,
Gender varchar(500) NOT NULL
);

ALTER TABLE Producer ADD CONSTRAINT PK_Producer PRIMARY KEY CLUSTERED (ProducerId);

CREATE TABLE Movie
(
MovieId int IDENTITY(1,1) NOT NULL,
MovieName varchar(500) NOT NULL,
ProducerId int NOT NULL,
Plot nvarchar(max) NOT NULL,
DateOfRelease date NOT NULL,
CreatedTime Datetimeoffset(3) NOT NULL,
UpdatedTime Datetimeoffset(3) NULL
);

ALTER TABLE Movie ADD CONSTRAINT PK_Movie PRIMARY KEY CLUSTERED (MovieId);

ALTER TABLE Movie ADD FOREIGN KEY (ProducerId) REFERENCES Producer (ProducerId);

CREATE TABLE Actor
(
ActorId int IDENTITY(1,1) NOT NULL,
ActorName varchar(500) NOT NULL,
Bio nvarchar(max) NULL,
DateOfBirth date NOT NULL,
Gender varchar(500) NOT NULL
);

ALTER TABLE Actor ADD CONSTRAINT PK_Actor PRIMARY KEY CLUSTERED (ActorId);

CREATE TABLE dbo.moviescommittedbyactors
(
ActorCommittedId int IDENTITY(1,1) NOT NULL,
ActorId int NOT NULL,
MovieId int NULL
);

ALTER TABLE moviescommittedbyactors ADD CONSTRAINT PK_moviescommittedbyactors PRIMARY KEY CLUSTERED (ActorCommittedId);

ALTER TABLE moviescommittedbyactors ADD FOREIGN KEY (MovieId) REFERENCES dbo.Movie(MovieId);

ALTER TABLE moviescommittedbyactors ADD FOREIGN KEY (ActorId) REFERENCES dbo.Actor(ActorId);
