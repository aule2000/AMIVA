---
numbersections: yes
documentclass: VUMIFPSbakalaurinis #report
papertype: PSI II 1 laboratorinis darbas
toc: yes
title-meta: AMIVA Smart Saver
title: AMIVA Smart Saver
author: |
    Andrius Pukšta  
    Auksė Levonaitė  
    Ignas Bujevičius  
    Modestas Gražys  
    Vytautas Lėveris
date: Vilnius - 2021
header-includes: |
    \papertype{PSI II 1 laboratorinis darbas}
    \university{Vilniaus universitetas}
    \faculty{Matematikos ir informatikos fakultetas}
    \authordescription{Atliko PS 2 kurso 5 grupės studentai:}
    \usepackage{pdfpages}
...

# Išorinė analizė

Vizija: Visi žmonės supranta ir valdo savo finansus.

Misija: Suteikti galimybę žmonėms sekti savo finansus ir siekti užsibrėžtų tikslų.

## Įvestis / išvestis

![Paveiksliukas rodo verslo įvesties ir išvesties diagramą. Diagramos turinys sutampa su aprašymu apačioje.](lab1/ivestis-isvestis.png)
*1 pav. Įvesties / išvesties diagrama*

Įvesties / išvesties diagramos aprašymas (1 pav.):
Šioje diagramoje pateikiama mūsų verslo įvestis ir išvestis.  Dalis lėšų gaunama iš reklamos pačioje web programėlėje, taip pat vartotojai naudodamiesi šią aplikaciją gali paremti jos gyvavimą. Kad aplikacija pritrauktų kuo daugiau klientų, ji yra nuolat tobulinama: tobulinamas dizainas ir įvairūs funkciniai aspektai. Nepaisant to, kad sukuriama patogi ir vartotojui pritaikyta išmani taupymo web aplikacija, reikia mokėti už pačios aplikacijos reklamą, hosting‘ą bei programuotojams, kurie tobulina aplikacijos funkcijas.

## Įvaizdis
Labai paprastai naudojama ir lengvai valdoma automatizuota taupymo platforma, kuri leidžia kiekvieną mėnesį įsivertinti savo biudžetą ir pagal tai keltis išvadas apie taupymo sugebėjimus, taip pat planuotis stambesnių pirkinių įsigijimą. Ši platforma sutaupo laiko žmonėms, kurie ankščiau nesinaudoję platforma savo biudžetą įsivertindavo rankiniu būdu skaičiuodami pajamas ir išlaidas ant popieriaus.

## Domeno modelis

![Paveiksliukas rodo domeno modelio diagramą. Diagramos turinys sutampa su aprašymu po paveiksliuku.](lab1/Domeno_Modelis.png)  
*2 pav. Domeno modelis*

Domeno modelio aprašymas (2 pav.):
Vartotojas gauna pasikartojančias ir vienkartines pajamas, leidžia išlaidas ir mato savo dabartinį balansą. Taip pat varototjas ssau kelia tikslus. Pajamos augina balansą, išlaidos jį mažina. Balansas yra reikalingas tikslui.


## 5 Porterio jėgos:
- Naujų konkurentų grėsmė:
    - Ateiti į rinką lengva (nereikia didelių investicijų į fizinę ar programinę įrangą)
- Tiekėjai:
    - Daug tiekėjų (daugybė kompanijų siūlo hostinimo paslaugas)
    - Sudėtinga pakeisti tiekėją (programinė įranga būna keliose skirtingose vietose ir priklauso viena nuo kitos, todėl sudėtinga perkelti pas kitą hostinimo tiekėją)
- Konkurencija šakoje:
    - Daug konkurentų (pvz.: Mint, PocketGuard, You Need A Budget, Wally, Mvelopes, Goodbudget, Personal Capital ir t.t)
    - Pigu pasitraukti iš rinkos (nėra / nedaug investicijų į fizinę įrangą)
- Vartotojai:
	- Potencialūs naudotojai - visa populiacija
    - Ivairaus amžiaus, bet daugiausia jaunesni (besinaudojantys kompiuteriais)
- Pakaitalų grėsmė:
    - Didelė, nesunku sukurti pakaitalą (programinė įranga gana nesudėtinga)
    - Egzistuojančios aplikacijos turi daugumą mūsų planuojamo funkcionalumo, todėl nesame išskirtiniai

## Reguliacinė aplinka
### Bendrasis duomenų apsaugos reglamentas
1. Gautas  asmens sutikimas
2. Gautas tėvų sutikimas, jeigu asmuo yra vaikas
3. Užtikrinama galimybė atšaukti sutikimą
4. Nurodoma kas gaus asmens duomenis (aktualu naudojant duomenis marketingo tikslais)
5. Užtikrinta teisė susipažinti su savo asmens duomenimis nemokamai
6. Užtikrintas duomenų saugumas
7. Užtikrinta teisė reikalauti ištrinti duomenis

### Duomenų saugumo pažeidimai
- Duomenų saugumas pažeidžiamas tuomet, kai asmens duomenys, už kuriuos atsakoma, atsitiktinai arba neteisėtai atskleidžiami neteisėtiems gavėjams arba tokie duomenys tampa laikinai neprieinami arba pakeičiami
- Jeigu įvyksta duomenų saugumo pažeidimas, kuris kelia pavojų asmens teisėms ir laisvėms, turėtų būti per 72 valandas nuo to momento, kai buvo sužinota apie pažeidimą, informuojama duomenų apsaugos institucija
- Nesilaikant BDAR gali būti skiriamos didelės baudos, kurios už tam tikrus pažeidimus sudaro 4 proc. įmonės pasaulinės apyvartos
- Nesilaikant BDAR duomenų apsaugos institucija gali imtis papildomų privalomų taisomųjų veiksmų, pavyzdžiui, nurodyti nustoti tvarkyti asmens duomenis

### Specialios duomenų kategorijos

Norint kaupti duomenis, priskiriamus specialiosioms duomenų kategorijoms, pavyzdžiui, pirštų antspaudus, duomenis tvarkyti turi būti paskirtas duomenų apsaugos pareigūnas.


# Proceso analizė

## Dabartinis procesas

![Paveiksliukas rodo dabartinio taupymo tikslo proceso BPMN modelio diagramą. Proceso eiga atitinka proceso aprašymą po paveiksliuku.](lab1/seno-proceso-bpmn.png)  
*3 pav. Dabartinio taupymo tikslo proceso BPMN modelis*

Dabartinis procesas (3 pav.):
Naudotojas sukuria taupymo tikslą ir pabaigos datą. Tada, kai naudotojas prideda pinigų prie savo taupymo tikslo, programa patikrina, ar tikslas pasiektas. Jei taip, tikslas uždaromas. Jei ne, naudotojas gali vėliau pridėti pinigų prie taupymo tikslo ir taip toliau.

## Būsimas procesas

![Paveiksliukas rodo būsimo taupymo tikslo proceso BPMN modelio diagramą. Proceso eiga atitinka proceso aprašymą po paveiksliuku.](lab1/naujo-proceso-bpmn.png)  
*4 pav. Būsimo taupymo tikslo proceso BPMN modelis*

Būsimas procesas (4 pav.):
Naudotojas gali sukurti taupymo tikslą keliais būdais. Jeigu jis dar nėra pateikęs savo pajamų ir išlaidų, taupymo tikslui pasiekti planą turi sukurti pats. Jei yra pateikęs savo pajamas ir išlaidas, sukūrus taupymo tikslą programa pati sukuria taupymo planą. Jei planas naudotojui netinka, jis gali jį pakeisti arba atšaukti. Jeigu naudotojas nusprendžia vykdyti planą, jis vis atnaujina savo pajamas ir išlaidas. Kiekvieną kartą atnaujinus pajamas ir išlaidas, programa pažiūri, ar taupymo tikslas pasiektas. Jei taip, tikslas uždaromas. Jei ne, programa arba pati perskaičiuoja plano pokyčius, arba leidžia naudotojui tai padaryti. Jei naudotojas yra nepatenkintas planu, jis bet kuriuo metu gali jį pakeisti arba atšaukti.

## Palyginimas

Dabartinio proceso metu nėra taupymo plano. Yra tik tikslas ir galima pridėti pinigų prie to tikslo. Taip pat naudotojas negali atšaukti ar pakeisti sukurto taupymo tikslo. Būsimo taupymo tikslo proceso metu programa gali pati sudaryti ir atnaujinti taupymo planą, taip pat naudotojas gali sudaryti / ištrinti / pakeisti taupymo planą ir tikslą bet kuriuo metu.

# Poreikiai ir reikalavimai

## Poreikiai

### Suinteresuotos šalys
 
- Naudotojai
- Programos kūrėjai

### Naudotojų poreikiai

- Biudžetų sudarymas
	- automatininis
	- naudotojas sudaro
	- pasirinktam laikotarpiui
- Reguliarios išlaidos
- Vienkartinės išlaidos
- Reguliarios pajamos
- Vienkartinės pajamos
- Investicijos (galimybė pažymėti pinigus kaip investuotus)
	- Duodančios reguliarią gražą (taupomieji indėliai ir kt.)
	- Nestabilios (akcijos ir kt.)
- Taupymo tikslai
	- Reguliarus pinigų atidėjimas tikslui
	- Vienkartinis pinigų pridėjimas
	- Tikslo pakeitimas, atšaukimas
- Statistikos
	- Pajamų
	- Išlaidų
	- Pasirinktam laikotarpiui
- Programa (tinklalapis) greitai veikia
- Informacijos tankis: reikia matyti kuo daugiau reikalingos informacijos ekrane vienu metu
- Kompiuterio ir mobilus UI
- Intuityvus, paprastas, lengvai išmokstamas naudoti UI
- Skirtingų kalbų palaikymas
- Skirtingų valiutų palaikymas
- Duomenų importavimas / eksportavimas

### Programos kūrėjų poreikiai

- Patogu plėsti funkcionalumą
- Programos veikimą galima lengvai ištestuoti

## Reikalavimai

### Funkciniai

1. Sistema naudotis gali vartotojo paskyrą susikūrę naudotojai
2. Sistemos naudotojai registruoja gaunamas pajamas ir patiriamas išlaidas. Ir pajamos, iį išlaidos gali būti reguliarios arba vienkartinės.
3. Programa pateikia detalią pasirinkto laikotarpio finansinę ataskaitą, kurią vartotojas galėtų išsisaugoti
4. Programa, stebėdama, kaip kinta vartotojo pajamos/išlaidos, siūlo siekti balansą didinančius tikslus, kuriuos vartotojas gali priimti ir įtraukti į siektinų tikslų sąrašą arba atmesti
5. Visi tikslai bet kada gali būti pakeičiami/redaguojami
6. Programa turi reguliariai informuoti, kaip sekasi siekti užsibrėžtų tikslų ir duoti patarimus, ką būtų galima keisti valdant pinigines operacijas
7. Vartotojas turi galimybę susikurti personalizuotus nustatymus, reguliuojančius balanso rodymą, pasiūlymų formas ir dažnumą, įvairių vartotojo pranešimų valdymą
8. Programa geba sugeneruoti dabartinės vartotojo finansinės situacijos apžvalgą
9. Kelių sąskaitų režimas (sąskaitas tvarkyti galima atskirai arba finansines operacijas fiksuoti bendrai visam biudžetui)
10. Programa palaiko skirtingas vartotojo sąsajos kalbas, naudotjas gali pakeisti kalbą.
11. Programa palaiko skirtingas valiutas.
12. Pinigus galima pažymeti kaip investuotus - gali būti su fiksuotomis palūkanomis (automatiškai programa priskaičiuoja) arba nestabilios investicijos (akcijos ir pan.), tokiu atveju naudotojas pats turi keisti investicijos vertę
13. Galima kategorizuoti išlaidas (reguliarios / vienkartinės, naudotojas pats gali suteikti kategorijoms pavadinimus)
14. Biudžetų sudarymo galimybės:
	- Automatiškai sudaryti (pagal dabartines reguliarias pajamas ir išlaidas)
	- Naudotojo sudaryti
	- Pajamos
		- Reguliarios
		- Vienkartinės
		- Palūkanų
		- Kitų investicijų
	- Išlaidos
		- Reguliarios
		- Nereguliarios, bet tikėtinos
		- Nenumatytos
		- Investicijos (stabilios ir nestabilios)
	- Iki metų galo
	- Visų metų
	- Galimybė kopijuoti dabar aktyvų biudžetą
	- Galimybė keisti aktyvų biudžetą
	- Galimybė keisti šabloninius biudžetus
	- Vienas biudžetas vienu metu yra aktyvus
	- Neaktyvus biudžetas gali būti pritaikytas (paverstas aktyviu) iki jame numatyto laikotarpio galo, net jei laikotarpis jau prasidėjęs
	- Galimybė biudžetą atšaukti (jeigu jau pradėtas vykdyti)
	- Šabloniniai (t.y. išsaugomi ir taikomi bet kuriam biudžeto ilgio laikotarpiui)
	- Vienkartiniai (sudaromi vienam kartui)
	- Iki mėnesio galo
	- Metiniai
		- Visiems mėnesiams vienodai
		- Visiems mėnesiams skirtingai
		- Pasirinktinai
	- Mėnesiniai
	- Pasirinktų laiko tarpų
15. Finansinės simuliacijos (naudotojas gali sukurit scenarijus ir prasukdamas laiką žiūrėti, kaip pasikeitė pinigų kiekis)
	- Investicijų su palūkanomis
	- Pajamų
	- Išlaidų
16. Duomenų importavimas iš failų ir bankų suvestinių.
17. Duomenų eksportavimas į failus.
18. Vertingos nuosavybės išsaugojimas
19. Visos nuosavybės ir lėšų bendros vertės statistika
20. Reguliarių pajamų statistika
21. Vienkartinių pajamų statistika
22. Visų išlaidų statistika
23. Visų pajamų statistika
24. Būtinųjų išlaidų statistika
25. Nebūtinųjų išlaidų statistika
26. Pasirinktų išlaidų kategorijų statistika
27. Komunalinių mokesčių statistika

### Nefunkciniai

101. Dokumentacija
	- visos funkcijos turi būti dokumentuotos, dokumentacija prieinama naudotojui
102. Prienamumas
	- turi veikti prastomis tinklo sąlygomis
	- tinkamas naudotojams su regos negalia
103. Lengvai plečiama
	- komponentus galima panaudoti daug kartų
104. Saugumas:
	- Naudojama tik HTTPS
    - Slaptažodžiai turi atitikti aukštus saugumo reikalavimus (mažiausiai 8 simboliai, būtinai bent vienas skaitmuo, didžioji raidė, specialusis simbolis)
    - atsarginių kopijų darymas
    - vienas vartotojas gali turėti tik vieną paskyrą sistemoje (paskyra susiejama su el. pašto adresu taip garantuojant, kad nebus kitos paskyros su tuo pačiu paštu)
    - Apsauga nuo SQL injekcijų (iš serverio pusės)
    - Slaptažodžiai duomenų bazėje saugomi užkoduoti ne žemesniu nei SHA-256 algoritmu
    - Slaptažodžių pakeitimo naudojant el. pašto adresą funkcija
105. Patikimumas:
    - Serveris užklausas apdoroja greitai (iki 3 s blogiausiu atveju)
    - Detalus finansinių duomenų validavimas (negali būti jokių interpretacijų suvedinėjant duomenis)
106. Naudojimas:
    - Lankstus ir pritaikomas pagal naudotojo poreikius dizainas
    - Galimybė keisti įvairių režimų stilius, foną, spalvą
    - Į paštą siunčiami svarbūs pranešimai ar perspėjimai iš sistemos, informuojantys apie tikslų siekimą ir siūlantys metodus jiems geriau siekti

### Atsekamumo matrica

\includepdf[pages=-,noautoscale=true,pagecommand={}]{lab1/traceability-matrix.pdf}	
*5 pav. Atsekamumo matrica*

Atsekamumo matrica rodo, ar visi reikalavimai padengia vartotojų poreikius. Didžiąją dalį poreikių padengia, tačiau nėra įgyvendinta, jog sistemos vartotojo sąsaja būtų prieinama ne tik kompiuterių, bet ir mobiliųjų telefonų vartotojams. Taip pat neatkreiptas dėmėsys į sistemos (tinklalapio) našumą, o tai vartotojui yra labai svarbu.