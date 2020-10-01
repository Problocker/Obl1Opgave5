# Opgave 5 TCP-server
https://docs.google.com/document/d/e/2PACX-1vScjTyYryIHsiK5d_HCOLf6Q6CSgj2J76fUOpVkPKsuYTRQ50OgM9JBGnZtbpQhpooEyp_jZde7i_vg/pub

Du skal lave en TCP-server som en Console Application. Applikationen skal være en concurrent server, der kan håndtere flere klienter og som kører på port 4646.


Serveren skal kunne håndtere cykler af samme type, som du allerede har lavet i opgave 1. Serveren skal kunne forstå følgende request (protokol), der er altid to linjer (dvs. Serveren skal have to ReadLine() kald):


HentAlle                // Der henter alle cykler fra serveren, linie to er tom
                        
fx HentAlle
 

Hent                        // Der henter en cykel med pågældende id

<<id>>                
fx Hent
   12


Gem                         // Der gemmer en cykel

<<cykel som json>>        

fx Gem
   {"ID":123,"Farve":"gul","Gear":7,“Pris:4700}

Serveren har en statisk liste til at holde cykel elementerne.
HentAlle returnerer en liste af cykler som en JsonString, Hent returnerer en cykel som en JsonString, Mens Gem ikke returnerer noget.

Du skal afprøve din løsning med SocketTest.
