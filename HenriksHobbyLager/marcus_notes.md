# Marcus notes

# Refactoring stage

Allmän refactory för att slippa framtida buggar innan jag börjar dela upp koden.  
Snyggade upp koden rent allmänt.

# Dela upp koden

Nu delar jag upp koden i interface, klasser och metoder.
- Först rensar jag main() som är en godklass..
- Flyttade main till ett huvudprogram
- Skapade repository som hanterar databasen
- Skapade fejk-repository för test
- Skapade ett interface för Repository baserad på Listan
