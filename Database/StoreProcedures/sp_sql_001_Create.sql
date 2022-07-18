USE [LocalDB]

go

/****** Object:  StoredProcedure [dbo].[CreateMovies]    Script Date: 18-07-2022 20:27:51 ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

ALTER PROCEDURE [dbo].[Createmovies] (@MovieName     VARCHAR(500),
                                      @Plot          NVARCHAR(max),
                                      @DateOfRelease DATE,
                                      @ProducerId    INT,
                                      @Actor_List    [USERDEFINEDTABLE] readonly
,
                                      @Movie_Id      INT output)
AS
  BEGIN
      SET nocount ON

      BEGIN TRAN

      BEGIN try
          DECLARE @MovieId INT

          --DECLARE @Movie_Id INT = 0 
          -- Delete MovieId from ActorsCommittedMovies before deleting it from Movie table 
          DELETE FROM [dbo].[actorscommittedmovies]
          WHERE  movieid IN (SELECT movieid
                             FROM   [dbo].[movie]
                             WHERE  Upper(moviename) = Upper(@MovieName)
                                    AND producerid = @ProducerId
                                    AND Upper(plot) = Upper(@Plot)
                                    AND dateofrelease = @DateOfRelease)

          -- Delete from Movie If already exits 
          DELETE FROM [dbo].[movie]
          WHERE  Upper(moviename) = Upper(@MovieName)
                 AND producerid = @ProducerId
                 AND Upper(plot) = Upper(@Plot)
                 AND dateofrelease = @DateOfRelease

          -- Insert into Movie
          INSERT INTO [dbo].[movie]
                      (moviename,
                       producerid,
                       plot,
                       dateofrelease,
                       createdtime)
          VALUES     (@MovieName,
                      @ProducerId,
                      @Plot,
                      @DateOfRelease,
                      Getutcdate())

          SET @MovieId=Scope_identity()

          -- Insert into [ActorsCommittedMovies] 
          INSERT INTO [dbo].[actorscommittedmovies]
                      (actorid,
                       movieid)
          (SELECT actorid,
                  @MovieId
           FROM   @Actor_List)

          SET @Movie_Id = @MovieId

          -- if not error, commit the transcation
          COMMIT TRANSACTION
      END try

      BEGIN catch
          SET @Movie_Id = -1

          -- if error, roll back any chanegs done by any of the sql statements
          ROLLBACK TRANSACTION
      END catch
  END 