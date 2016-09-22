CREATE TABLE TRIPS (TRIP_ID INTEGER PRIMARY KEY AUTOINCREMENT, TRIP_TITLE VARCHAR(100), 
					TRIP_DESCRIPTION TEXT, TRIP_URL VARCHAR(100), 
					ADDED_DATE DATETIME, ADDED_BY UNIQUEIDENTIFIER,
					UPDATED_DATE DATETIME, UPDATED_BY UNIQUEIDENTIFIER)

GO

CREATE TABLE TRIP_IMAGES (IMAGE_ID INTEGER PRIMARY KEY AUTOINCREMENT, TRIP_ID INTEGER, IMAGE_TITLE VARCHAR(100), 
						  IMAGE_FILE VARCHAR(200), IMAGE_DESC TEXT, IMAGE_URL VARCHAR(100), IS_COVER BIT,
						  ADDED_DATE DATETIME, ADDED_BY UNIQUEIDENTIFIER,
						  UPDATED_DATE DATETIME, UPDATED_BY UNIQUEIDENTIFIER,
						  CONSTRAINT FK_TRIP_IMAGES_TRIP_ID FOREIGN KEY (TRIP_ID) REFERENCES TRIPS (TRIP_ID))
						  
GO

CREATE TABLE BLOGS (BLOG_ID INTEGER PRIMARY KEY AUTOINCREMENT, BLOG_TITLE VARCHAR(100), 
					BLOG_CONTENT TEXT, BLOG_CONTENT_OVERVIEW TEXT,
					BLOG_URL VARCHAR(100), BLOG_ORIGINAL_URL VARCHAR(500),
					ADDED_DATE DATETIME, ADDED_BY UNIQUEIDENTIFIER,
					UPDATED_DATE DATETIME, UPDATED_BY UNIQUEIDENTIFIER)
					
GO

CREATE TABLE KIDS_CORNER (ID INTEGER PRIMARY KEY AUTOINCREMENT, TITLE VARCHAR(200), 
						  [DESCRIPTION] TEXT, URL VARCHAR(100), 
						  ADDED_DATE DATETIME, ADDED_BY UNIQUEIDENTIFIER,
						  UPDATED_DATE DATETIME, UPDATED_BY UNIQUEIDENTIFIER)
						  
GO

CREATE TABLE KIDS_CORNER_IMAGES (IMAGE_ID INTEGER PRIMARY KEY AUTOINCREMENT, KIDS_ID INTEGER, IMAGE_TITLE VARCHAR(100), 
								 IMAGE_FILE VARCHAR(200), IMAGE_DESC TEXT, IMAGE_URL VARCHAR(100), IS_COVER BIT,
							     ADDED_DATE DATETIME, ADDED_BY UNIQUEIDENTIFIER,
								 UPDATED_DATE DATETIME, UPDATED_BY UNIQUEIDENTIFIER,
								 CONSTRAINT FK_KIDS_CORNER_IMAGES_KIDS_ID FOREIGN KEY (KIDS_ID) REFERENCES KIDS_CORNER (ID))
								 
GO

CREATE TABLE USERS ([USER_ID] UNIQUEIDENTIFIER, FIRST_NAME VARCHAR(100), LAST_NAME VARCHAR(100), SALUTATION VARCHAR(10),
					[PASSWORD] VARBINARY(8000), [DESCRIPTION] TEXT, URL VARCHAR(100), PROFILE_PIC VARCHAR(200),
					ADDED_DATE DATETIME, UPDATED_DATE DATETIME,
					CONSTRAINT PK_USERS_USER_ID PRIMARY KEY ([USER_ID]))
								 