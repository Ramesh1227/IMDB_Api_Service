USE [LocalDB]

go

/****** Object:  StoredProcedure [dbo].[UpdateMovieDetails]    Script Date: 18-07-2022 20:00:32 ******/
SET ansi_nulls ON

go

SET quoted_identifier ON

go

CREATE PROCEDURE [dbo].[Updatemoviedetails] (@MovieId       INT,
                                             @MovieName     VARCHAR(500),
                                             @Plot          NVARCHAR(max),
                                             @DateOfRelease DATE,
                                             @ProducerId    INT,
                                             @Actor_List    [USERDEFINEDTABLE]
readonly)
AS
  BEGIN
      SET nocount ON

      BEGIN TRAN

      BEGIN try
          DECLARE @Movie_Id INT = 0

          DELETE FROM [dbo].[actorscommittedmovies]
          WHERE  movieid = @MovieId

          -- Insert into [ActorsCommittedMovies] 
          INSERT INTO [dbo].[actorscommittedmovies]
                      (actorid,
                       movieid)
          (SELECT actorid,
                  @MovieId
           FROM   @Actor_List)

          UPDATE movie
          SET    moviename = @MovieName,
                 plot = @Plot,
                 dateofrelease = @DateOfRelease,
                 producerid = @ProducerId,
                 updatedtime = Getutcdate()
          WHERE  movieid = @MovieId

          SET @Movie_Id = @Movie_Id

          -- if not error, commit the transcation
          COMMIT TRANSACTION
      END try

      BEGIN catch
          SET @Movie_Id = -1

          -- if error, roll back any chanegs done by any of the sql statements
          ROLLBACK TRANSACTION
      END catch
  END

go 