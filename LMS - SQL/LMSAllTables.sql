CREATE TABLE AdminDetails
(
	AdminID int Primary Key IDENTITY,
	FirstName varchar(50),
	LastName varchar(50),
	Email varchar(50),
	Password varchar(50),
	ContactNumber varchar(50),
	IsVerified bit,
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Unique (Email)
)

CREATE TABLE HiredCandidate
(
	ID int Primary Key IDENTITY,
	FirstName varchar(50),
	MiddleName varchar(50),
	LastName varchar(50),
	Email varchar(50),
	Degree varchar(50),
	MobileNumber varchar(50),
	PermanentPincode varchar(50),
	HiredCity varchar(50),
	HiredDate datetime,
	HiredLab varchar(50),
	Attitude varchar(50),
	CommunicationRemark varchar(50),
	KnowledgeRemark varchar(50),
	AggregateRemark varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Unique (Email)
)

Create table FellowshipCandidate
(
	CandidateID int Primary Key Identity,
	FirstName varchar(50),
	MiddleName varchar(50),
	LastName varchar(50),
	Email varchar(50),
	Degree varchar(50),
	MobileNumber varchar(50),
	PermanentPincode varchar(50),
	HiredCity varchar(50),
	HiredDate datetime,
	HiredLab varchar(50),
	Attitude varchar(50),
	CommunicationRemark varchar(50),
	KnowledgeRemark varchar(50),
	AggregateRemark varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	BirthDate varchar(50),
	IsBirthDateVerified bit,
	ParentName varchar(50),
	ParentOccupation varchar(50),
	ParentsMobileNumber varchar(50),
	ParentsAnnualSalary varchar(50),
	LocalAddress varchar(100),
	PermanentAddress varchar(100),
	PhotoPath varchar(100),
	JoiningDate varchar(50),
	CandidateStatus varchar(50),
	PersonalInformation varchar(100),
	BankInformation varchar(100),
	EducationalInformation varchar(100),
	DocumentStatus varchar(50),
	Remark varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Unique (Email)
)

CREATE TABLE CandidateBankDetails
(
	ID int Primary Key Identity,
	CandidateID int,
	Name varchar(50),
	AccountNumber varchar(50),
	IsAccountNumberVerified bit,
	IfscCode varchar(50),
	IsIfscCodeVerified bit,
	PanNumber varchar(50),
	IsPanNumberVerified bit,
	AdhaarNumber varchar(50),
	IsAdhaarNumberVerified bit,
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key (CandidateID)
	References FellowshipCandidate(CandidateID)
)

Create table CandidateQualification
(
	ID int Primary Key Identity,
	CandidateID int,
	Diploma varchar(50),
	DegreeName varchar(50),
	IsDegreeNameVerified bit,
	EmployeeDiscipline varchar(50),
	IsEmployeeDisciplined bit,
	PassingYear varchar(50),
	IsPassingYearVerified bit,
	AggregatePer varchar(50),
	IsAggregatePerVerified bit,
	FinalYearPer varchar(50),
	IsFinalYearPerVerified bit,
	TrainingInstitute varchar(50),
	IsTrainingInstituteVerified bit,
	TrainingDurationMon varchar(50),
	IsTrainingDurationMonVerified bit,
	OtherTraining varchar(50),
	IsOtherTrainingVerified bit,
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key (CandidateID)
	References FellowshipCandidate(CandidateID)
)

create table CandidateDocuments
(
	ID int Primary key Identity,
	CandidateID int,
	DocType varchar(50),
	DocPath varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key (CandidateID)
	References FellowshipCandidate(CandidateID)
)
create table CompanyDetails
(
	CompanyID int Primary key Identity,
	Name varchar(50),
	Address varchar(100),
	Location varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime
)
create table TechStack
(
	ID int Primary key Identity,
	TechName varchar(50),
	ImagePath varchar(50),
	Framework varchar(50),
	CurrentStatus varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime
)

create table TechType
(
	ID int Primary key Identity,
	TypeName varchar(50),
	CurrentStatus varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime
)

create table Lab
(
	LabID int Primary key Identity,
	Name varchar(50),
	Location varchar(50),
	Address varchar(150),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime
)

create table LabThreshold
(
	ID int Primary key Identity,
	LabID int,
	LabCapacity varchar(50),
	LeadThreshold varchar(50),
	IdeationEnggThreshold varchar(50),
	BuddyEnggThreshold varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key (LabID)
	References Lab(LabID)
)

CREATE TABLE Mentor
(
	MentorID int Primary key Identity,
	Name varchar(50),
	MentorType varchar(50),
	LabID int,
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key(LabID)
	References Lab(LabID)
)

CREATE TABLE MentorIdeationMap
(
	ID int Primary Key Identity,
	LeadID int,
	MentorID int,
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key(LeadID)
	References Mentor(MentorID),
	Foreign Key(MentorID)
	References Mentor(MentorID)
)

create table MentorTechStack
(
	ID int Primary key Identity,
	MentorID int,
	TechStackID int,
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key(MentorID)
	References Mentor(MentorID),
	Foreign Key(TechStackID)
	References TechStack(ID)
)
create table MakerProgram
(
	MakerProgramID int Primary key Identity,
	ProgramName varchar(50),
	ProgramType varchar(50),
	ProgramLink varchar(50),
	TechStackID int,
	TechTypeID int,
	IsProgramApproved bit,
	DescriptionStatus varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate DateTime,
	ModifiedDate DateTime,
	Foreign Key(TechStackID)
	References TechStack(ID),
	Foreign Key(TechTypeID)
	References TechType(ID)
)
create table CompanyRequirement
(
	RequirementID int Primary key Identity,
	CompanyID int,
	RequestedMonth varchar(50),
	City varchar(50),
	IsDocVerified bit,
	RequirementDocPath varchar(50),
	NumOfEngg varchar(50),
	TechStackID int,
	TechTypeID int,
	MakerProgramID int,
	LeadID int,
	IdeationEnggID int,
	BuddyEnggID int,
	SpecialRemark varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key(CompanyID )
	References CompanyDetails(CompanyID ),
	Foreign Key(TechStackID)
	References TechStack(ID),
	Foreign Key(TechTypeID)
	References TechType(ID),
	Foreign Key(MakerProgramID)
	References MakerProgram(MakerProgramID),
	Foreign Key(LeadID)
	References Mentor(MentorID),
	Foreign Key(IdeationEnggID)
	References Mentor(MentorID),
	Foreign Key(BuddyEnggID)
	References Mentor(MentorID)
)
create table CandidateTechStackAssignment
(
	ID int Primary key Identity,
	RequirementID int,
	CandidateID int,
	AssignDate varchar(50),
	Status varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime,
	Foreign Key(RequirementID)
	References CompanyRequirement(RequirementID),
	Foreign Key(CandidateID)
	References FellowshipCandidate(CandidateID)
)
create table AppParameters
(
	ID int Primary key Identity,
	KeyType varchar(50),
	KeyValue varchar(50),
	KeyText varchar(50),
	CurentStatus varchar(50),
	LastUpdateUser varchar(50),
	LastUpdateStamp varchar(50),
	CreatorStamp varchar(50),
	CreatorUser varchar(50),
	CreatedDate Datetime,
	ModifiedDate Datetime
)