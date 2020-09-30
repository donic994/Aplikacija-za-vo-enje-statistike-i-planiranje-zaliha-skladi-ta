# Aplikacija-za-vodenje-statistike-i-planiranje-zaliha-skladista
Ovaj rad prikazuje kreiranje stolne aplikacije za vođenje statistike i planiranje zaliha skladišta pomoću temporalnih i aktivnih baza podataka. Objašnjavaju se principi temporalnih i aktivnih baza podataka te se prikazuje implementacija istih. Automatizacija procesa je postignuta pomoću okidača u bazi podataka, tako da je proces naručivanja artikala sa skladišta u potpunosti automatiziran. Stolna aplikacija je rađena u Microsoft Visual Studio 2019 u C# jeziku kao Windows Forms aplikacija, a PostgreSQL je korišten za bazu podataka. Rad s aktivnim bazama podataka uvelike olakšava programiranje aplikacija pošto je većina logike pohranjena u ECU pravilima na bazi podataka.

Upute za pokretanje projekta:
1. Preuzeti pgAdmin sa https://www.pgadmin.org/download/ i instalirati na računalo
2. Importati filgatariDB datoteku iz datoteke Skladiste u PostgreSQL server(pgAdmin)
3. Preuzeti Microsoft Visual Studio 2019 sa https://visualstudio.microsoft.com/vs/community/ 
   i instalirati na računalo
4. Otvoriti Skladiste.sln iz datoteke Skladiste u Microsoft Visual Studio 2019
5. U klasi Database će se trebati promjeniti Connection parametri (server, port, username, password) 
   ukoliko nisu ostavljene default postavke pgAdmin-a
6. Start
