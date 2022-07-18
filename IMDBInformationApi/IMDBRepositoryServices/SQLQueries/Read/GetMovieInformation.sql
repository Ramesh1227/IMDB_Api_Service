SELECT MVI.movieid,
       MVI.moviename,
       MVI.plot,
       MVI.dateofrelease,
       PRO.producername,
	   AC.actorName
FROM   movie MVI
       JOIN producer PRO
         ON MVI.producerid = PRO.producerid
       JOIN actorscommittedmovies ACM
         ON MVI.movieid = ACM.movieid
       JOIN actor AC
         ON AC.actorid = ACM.actorid 