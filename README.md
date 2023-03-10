# Countries And Calculator

Lai uzsāktu projektu nepieciešams projektu noklonēt

Mājasdarbam ir pievienota datubāze. Datubāzei izmantoju Is Microsoft SQL Server Management Studio. 

#### Šādi izskatās mans SQL servers, lai varētu savienoties ar datubāzi (Savienošanās ar datubāzi nav obligāta aplikācijas darbībai) 
![image](https://user-images.githubusercontent.com/99561972/223776287-9672ae7b-94d0-4ba5-bc86-eb4d207db471.png)

#### Nepieciešamie soļi lai palaistu aplikāciju
1)Nepieciešams caur savu CMD uz jūsu datora navigēties uz folder, kurā atrodas projkets. Manā gadījumā tas ir šis. 
![image](https://user-images.githubusercontent.com/99561972/223777913-e00600aa-6459-4630-801b-28558b01a7ae.png)

2)Kad esam nonākuši līdz projekta folderim, ir nepieciešams veikt šādu komandu

    dotnet tool install --global dotnet-ef
    
Šī komanda instalē Entity Framework Core tools globāli uz jūsu ierīci, lai projekts var tikt palaists kā arī, lai var pievienot migrācijas caur cmd. 

3)Lai pievienotu migrācijas datubāzei un atjaunināt datubāzi mums jāveic šādas komandas iekš cmd. 

    dotnet ef migrations add calculations
    
Šī komanda pievienos migrāciju, kuru sauks calculations. Kad esam veikuši komandu, nepieciešams ievadīt šādu komandu: 
    
    dotnet ef database update

4) Kad esam to izdarījuši, nepieciešams uzsākt aplikācijas darbību ar komandu:

    dotnet build
    
šī komanda sapakos failu, kurš būs nepieciešams aplikācijas palaišanai, pēc tam ievadam: 

    dotnet run
    
Šī komanda uzsāks aplikācijas darbību.     


5) Kad aplikācija ir uzsākusi darbību ir nepieciešams savā pārlūkprogrammā navigēties uz šo saiti: 
    
      https://localhost:7146/swagger/index.html
      

6) Lai veiktu nepieciešamos izsaukumus, vajadzīgs mājasdarbā norādītais API-KEY "8c066128-ac81-4f7a-a956-1f9930bf477e", kuru jāievada uzpiežot "Authorize" pogu
    ekrāna labajā pusē. Pēc atslēgas ievades varam lauciņu aizvērt un veikt nepieciešamos API izsaukumus. 
Pirmie divi API izsaukumi saglabā vērtības datubāzē. (Otrajā uzdevumā, lai veiktu matemātikas darbību nepieciešams "/" simbola vietā ievadīt "div", piemēram: 5div5+5)

![image](https://user-images.githubusercontent.com/99561972/223783338-c40b6e24-956b-492c-a507-efb156cbd817.png)




![image](https://user-images.githubusercontent.com/99561972/224284233-b0866d18-a9ce-4e2c-b730-c0d8d27884f8.png)
