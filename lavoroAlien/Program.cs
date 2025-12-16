
namespace alien_parte_finale
{
    internal class Program
    {
        static string DialogoComando()
        {
            //gestione del dialogo nella sala di comando
            Console.WriteLine("Sei nella sala di comando.\n");

            Console.WriteLine("Mira Solenz: \"La situazione è instabile. Dobbiamo decidere ora.\"");
            Console.WriteLine("1) Chiedere un parere tattico a Drax");
            Console.WriteLine("2) Chiedere un’analisi scientifica a Vern");
            Console.WriteLine("3) Verificare lo stato dei sistemi con Karla");

            Console.Write("Scelta: ");
            int scelta;
            scelta = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            if (scelta == 1)
            {
                Console.WriteLine("Drax Morrow: \"Entriamo armati e mettiamo tutto in sicurezza.\"");
                Console.WriteLine("Taryn Wells: \"Approccio diretto, rischio elevato.\"");

                Console.WriteLine("1) Seguire il piano di Drax");
                Console.WriteLine("2) Frenare Drax e chiedere più dati");

                int sottoScelta;
                sottoScelta = Convert.ToInt32(Console.ReadLine());

                if (sottoScelta == 1)
                {
                    Console.WriteLine("\nMira Solenz: \"Decisione presa. Squadra d’assalto pronta.\"");
                    return "Missione offensiva avviata con Drax";
                }
                else
                {
                    Console.WriteLine("\nTaryn Wells: \"Scelta prudente. Raccogliamo più informazioni.\"");
                    return "Missione rimandata per analisi";
                }
            }
            else if (scelta == 2)
            {
                Console.WriteLine("Elias Vern: \"Ci sono segnali biologici anomali. Serve cautela.\"");
                Console.WriteLine("Mira Solenz: \"Quanto è grave?\"");

                Console.WriteLine("\n1) Fidarsi di Vern e rallentare");
                Console.WriteLine("2) Ignorare l’avviso e procedere");

                int sottoScelta;
                sottoScelta = Convert.ToInt32(Console.ReadLine());

                if (sottoScelta == 1)
                {
                    Console.WriteLine("\nElias Vern: \"Grazie. Questa scelta potrebbe salvarci.\"");
                    return "Missione scientifica attivata con Vern";
                }
                else
                {
                    Console.WriteLine("\nMira Solenz: \"Non possiamo fermarci ora.\"");
                    return "Missione avviata ignorando i rischi";
                }
            }
            else if (scelta == 3)
            {
                Console.WriteLine("Karla Rens: \"I motori tengono, ma i sensori sono instabili.\"");
                Console.WriteLine("Taryn Wells: \"Potremmo essere ciechi là fuori.\"");

                Console.WriteLine("1) Riparare i sensori");
                Console.WriteLine("2) Partire subito");

                int sottoScelta;
                sottoScelta = Convert.ToInt32(Console.ReadLine());

                if (sottoScelta == 1)
                {
                    Console.WriteLine("\nKarla Rens: \"Dammi qualche minuto e saremo pronti.\"");
                    return "Missione tecnica: sistemi migliorati";
                }
                else
                {
                    Console.WriteLine("\nTaryn Wells: \"Decisione rischiosa, ma registrata.\"");
                    return "Missione avviata con sensori danneggiati";
                }
            }
            else
            {
                Console.WriteLine("Scelta non valida.");
                return "Nessuna decisione presa";
            }
        }


        static (int nuovaVita, int medikitRimasti) UsaOggettoCura(int vitaGiocatore, int medikit)
        {
            //gestione dell'uso del medikit per curare il giocatore
            if (medikit <= 0)
            {
                Console.WriteLine("Non hai medikit!");
                return (vitaGiocatore, medikit);
            }

            Random rnd = new Random();
            int cura = rnd.Next(5, 21);

            vitaGiocatore += cura;
            if (vitaGiocatore > 100)
                vitaGiocatore = 100;

            medikit--;

            Console.WriteLine("Usi un medikit e recuperi " + cura + " punti vita.");
            Console.WriteLine("Vita attuale: " + vitaGiocatore);
            Console.WriteLine("Medikit rimasti:" + medikit);

            return (vitaGiocatore, medikit);
        }

        static int AttaccoGiocatore(int vitaAlieno)
        {
            //gestione dell'attacco del giocatore

            Random rnd = new Random();
            int danno = rnd.Next(5, 16); // 5–15 danni

            vitaAlieno -= danno;

            if (vitaAlieno < 0)
            {
                vitaAlieno = 0;
            }
                

            Console.WriteLine("Attacchi l'alieno e infliggi" + danno + "danni.");
            Console.WriteLine("Vita alieno:" + vitaAlieno);

            return vitaAlieno;
        }

        static int boost(int avanza, int passi, bool scassaP)
        {
            //gestione del boost dei passi
            Random random = new Random();
            int bonus = random.Next(1, 7);
            bool bost = false;
            if (scassaP == true)
            {
                Console.WriteLine("hai ricevuto un boost di 3 passi extra");
                avanza = passi + 3;
                bost = true;
            }
            else if (bonus > 4)
            {
                Console.WriteLine("hai ricevuto un boost di 2 passi extra");
                avanza = passi + 2;
                bost = true;
            }
            else
            {
                Console.WriteLine("non hai ricevuto nessun boost");
                avanza = passi;
                bost = false;
            }
            return avanza;
        }
        static string Imprevisti(string imprevisti)
        {
            //gestione degli imprevisti durante il gioco
            Random random = new Random();
            int evento = random.Next(1, 4);
            if (evento == 1)
            {
                Console.WriteLine("un membro dell'equipaggio è stato ferito dallo xenomorfo");
                imprevisti = "membro ferito";

            }
            else if (evento == 2)
            {
                Console.WriteLine("lo xenomorfo ha bloccato alcune porte");
                imprevisti = "porte bloccate";
            }
            else
            {
                Console.WriteLine("lo xenomorfo si è avvicinato molto, fai attenzione");
                imprevisti = "xenomorfo vicino";
            }
            return imprevisti;
        }
        static string turnoDIG(string turnoDIG, bool cacciatore, bool curatore, bool scassaP, bool armaletale, bool porteAPP, int proiettoli)
        {
            //gestione del turno di gioco
            //scelte del giocatore
            bool trovatoOggetto = false, sceltaConSuccesso = false;
            Random random = new Random();
            int OggaC = random.Next(1, 50);
            Console.WriteLine("è il tuo turno di giocare, scegli cosa fare:");
            Console.WriteLine("---------------------------");


            Console.WriteLine("1) preparare una trappola");


            Console.WriteLine("2) curare un membro dell'equipaggio");


            Console.WriteLine("3) provare a sbloccare le porte");

            Console.WriteLine("4) controllare per oggetti utili");

            Console.WriteLine("-----------------------------------");
            int sceltaTurno = Convert.ToInt32(Console.ReadLine());
            while (sceltaTurno < 1 || sceltaTurno > 4)
            {
                Console.WriteLine("scelta non valida, riprova");
                sceltaTurno = Convert.ToInt32(Console.ReadLine());
            }
            while (sceltaConSuccesso == false)
            {
                if (sceltaTurno == 1)
                {
                    if (cacciatore == true)
                    {
                        Console.WriteLine("hai preparato una trappola per l'alieno");
                        sceltaConSuccesso = true;
                        Random random1 = new Random();
                        int cattura = random1.Next(1, 10);
                        if (cattura > 5)
                        {
                            Console.WriteLine("hai catturato lo xenomorfo con successo!");
                            Console.WriteLine("complimenti sei riuscito a diminuire la sua velocità");
                            sceltaConSuccesso = true;
                        }
                        else
                        {
                            Console.WriteLine("lo xenomorfo è riuscito a sfuggire alla trappola");

                        }
                    }
                    else
                    {
                        Console.WriteLine("non sei in grado di preparare una trappola");
                        Console.WriteLine("scelta non valida, riprova");
                        sceltaTurno = Convert.ToInt32(Console.ReadLine());
                    }

                }
                else if (sceltaTurno == 2)
                {
                    if (curatore == true)
                    {
                        Console.WriteLine("hai curato un membro dell'equipaggio");
                        sceltaConSuccesso = true;
                    }
                    else
                    {
                        Console.WriteLine("non sei in grado di curare nessuno");
                        Console.WriteLine("scelta non valida, riprova");
                        sceltaTurno = Convert.ToInt32(Console.ReadLine());
                    }


                    Console.WriteLine("non puoi curare nessuno, non hai il kit medico");
                }
                else if (sceltaTurno == 3)
                {
                    Random random1 = new Random();
                    int segnale = random1.Next(1, 10);
                    if (segnale > 7)
                    {
                        Console.WriteLine("hai sbloccato tutte le porte con successo");
                        sceltaConSuccesso = true;
                    }
                    else
                    {
                        Console.WriteLine("non sei riuscito a sbloccare le porte");
                        Console.WriteLine("scelta non valida, riprova");
                        sceltaTurno = Convert.ToInt32(Console.ReadLine());
                    }

                }
                else
                {
                    Console.WriteLine("hai scelto di cercare oggetti utili");
                    sceltaConSuccesso = true;
                    if (OggaC > 25)
                    {
                        equipaggiamento(0, "", "");
                        Console.WriteLine("trovare un oggetto utile");

                        Random oggetto = new Random();
                        int oggettoTrovato = oggetto.Next(1, 4);
                        if (oggettoTrovato == 1)
                        {
                            Console.WriteLine("hai trovato un medikit");
                            curatore = true;
                        }
                        else if (oggettoTrovato == 2)
                        {
                            Console.WriteLine("hai trovato dei proiettili");
                            proiettoli += 10;
                            armaletale = true;
                        }
                        else if (oggettoTrovato == 3)
                        {
                            Console.WriteLine("hai trovato una chiave magnetica");
                            scassaP = true;
                        }
                    }

                    else
                    {
                        Console.WriteLine("non trovare nulla di utile");
                    }
                }
            }



            return turnoDIG;
        }


        static void AttaccoAlieno(ref int vita)
        {
            //gestione dell'attacco alieno
            Random rnd = new Random();
            int danno = rnd.Next(1, 11); // da 1 a 10

            vita -= danno;

            if (vita < 0)
            {
                vita = 0;
            }

            Console.WriteLine("       __.,,------.._\r\n      ,'\"   _      _   \"`.\r\n     /.__, ._  -=- _\"`    Y\r\n    (.____.-.`      \"\"`   j\r\n     VvvvvvV`.Y,.    _.,-'       ,     ,     ,\r\n        Y    ||,   '\"\\         ,/    ,/    ./\r\n        |   ,'  ,     `-..,'_,'/___,'/   ,'/   ,\r\n   ..  ,;,,',-'\"\\,'  ,  .     '     ' \"\"' '--,/    .. ..\r\n ,'. `.`---'     `, /  , Y -=-    ,'   ,   ,. .`-..||_|| ..\r\nff\\\\`. `._        /f ,'j j , ,' ,   , f ,  \\=\\ Y   || ||`||_..\r\nl` \\` `.`.\"`-..,-' j  /./ /, , / , / /l \\   \\=\\l   || `' || ||...\r\n `  `   `-._ `-.,-/ ,' /`\"/-/-/-/-\"'''\"`.`.  `'.\\--`'--..`'_`' || ,\r\n            \"`-_,',  ,'  f    ,   /      `._    ``._     ,  `-.`'//         ,\r\n          ,-\"'' _.,-'    l_,-'_,,'          \"`-._ . \"`. /|     `.'\\ ,       |\r\n        ,',.,-'\"          \\=) ,`-.         ,    `-'._`.V |       \\ // .. . /j\r\n        |f\\\\               `._ )-.\"`.     /|         `.| |        `.`-||-\\\\/\r\n        l` \\`                 \"`._   \"`--' j          j' j          `-`---'\r\n         `  `                     \"`,-  ,'/       ,-'\"  /\r\n                                 ,'\",__,-'       /,, ,-'\r\n                                 Vvv'            VVv'");

            Console.WriteLine("L'alieno ti ha attaccato! Perdi" + danno + " punti vita.");
            Console.WriteLine("Vita attuale:" + vita);
        }




        static string equipaggiamento(int quantità, string equipaggiamento, string sceltapersonaggio)
        {
            //gestione dell'equipaggiamento in base al personaggio scelto
            bool trappola = false, setAtt = false, taserAlt = false, scudoB = false, laptop = false;
            bool chiave = false, medikit = false, medikitAvv = false, scannerbiologico = false, dispoHAK = false;
            int proiettoli;

            Console.WriteLine("il tuo equipaggiamento attuale è:");
            if (sceltapersonaggio == "1")
            {
                equipaggiamento = "Chiave magnetica, Kit di pronto soccorso, Pistola stordente";
                proiettoli = 10; chiave = true; medikit = true;
            }
            else if (sceltapersonaggio == "2")
            {
                equipaggiamento = "Kit medico avanzato, Scanner biologico, Pistola stordente";
                proiettoli = 10; medikitAvv = true; scannerbiologico = true;
            }
            else if (sceltapersonaggio == "3")
            {
                equipaggiamento = "Set di attrezzi, Trappola EMP, Pistola stordente";
                proiettoli = 10; trappola = true; setAtt = true;
            }
            else if (sceltapersonaggio == "4")
            {
                equipaggiamento = "Taser ad alta potenza, Scudo balistico, Pistola stordente";
                proiettoli = 10; taserAlt = true; scudoB = false;
            }
            else if (sceltapersonaggio == "5")
            {
                equipaggiamento = "Laptop portatile, Dispositivo di hacking, Pistola stordente";
                proiettoli = 10; laptop = true; dispoHAK = true;
            }
            return equipaggiamento;
        }
        static int lancioDado()
        {
            Random dado = new Random();
            int risultato = dado.Next(1, 7);
            return risultato;
        }
        static string[] SCpercorso(bool scappato)
        {
            //gestione del percorso nelle stanze
            int avanza = boost(0, 0, false);

            int passi = lancioDado();
            string[] stanze = { "Ponte di Comando Holo-Visivo", "Camera di Navigazione Quantistica", "Sala Motori a Fusione Oscura", "Laboratorio Xenobiologico",
                "Modulo di Criostasi Profonda", "Orto Idroponico Bioluminescente", "Sala Olistica di Rilassamento Neurale", "Armeria a Campo Magnetico", "Centro di Comando Droni", "Archivio di Memoria Cristallina", "Sala di Teletrasporto Molecolare",
                "Blocco Medico Rigenerativo", "Corridoio di Gravità Variabile", "Simulatore Ambientale Totale", "Cupola Stellare Panoramica", "Sala dei Reattori Antimateria", "Centro di Comunicazione Tachionica", "Quartieri dell’Equipaggio Modulari",
                "Santuario del Silenzio Cosmico", "Hangar Multifase" };
            string stanzaRaggiunta;
            string stanzaAttuale = stanze[0];
            int posizioneIniziale = 0;
            posizioneIniziale = posizioneIniziale + passi;
            stanzaAttuale = stanze[posizioneIniziale];
            
            if (stanze[posizioneIniziale] == "Hangar Multifase")
            {
                Console.WriteLine("complimenti sei riuscito a scappare dall'alieno");
                scappato = true;
            }


            return stanze;

        }
        static string OttieniDescrizioneStanza(string nomeStanza)
        {
            // Con un array, il controllo andrebbe fatto sull'indice (ad esempio: if (indice == 0) {...})
            // Ma è più robusto e leggibile usare il nome della stanza come chiave di ricerca, come in questo esempio.

            if (nomeStanza == "Ponte di Comando Holo-Visivo")
            {
                return "Un'area operativa con schermi olografici che proiettano in 3D i dati tattici e la vista esterna.";
            }
            else if (nomeStanza == "Camera di Navigazione Quantistica")
            {
                return "Contiene il computer di bordo che calcola istantaneamente le rotte attraverso lo spazio-tempo.";
            }
            else if (nomeStanza == "Sala Motori a Fusione Oscura")
            {
                return "Il cuore pulsante della nave, dove una reazione controllata genera energia propulsiva illimitata.";
            }
            else if (nomeStanza == "Laboratorio Xenobiologico")
            {
                return "Attrezzato per l'analisi e lo studio di forme di vita e campioni organici alieni.";
            }
            else if (nomeStanza == "Modulo di Criostasi Profonda")
            {
                return "Contiene capsule per il sonno criogenico a lungo termine durante i viaggi interstellari.";
            }
            else if (nomeStanza == "Orto Idroponico Bioluminescente")
            {
                return "Un sistema ecologico autonomo per la coltivazione di cibo fresco sotto luci organiche.";
            }
            else if (nomeStanza == "Sala Olistica di Rilassamento Neurale")
            {
                return "Un ambiente di terapia sensoriale che riequilibra le onde cerebrali e lo stress dell'equipaggio.";
            }
            else if (nomeStanza == "Armeria a Campo Magnetico")
            {
                return "Custodisce armi e attrezzature in sicurezza grazie a potenti campi di forza.";
            }
            else if (nomeStanza == "Centro di Comando Droni")
            {
                return "Da qui si gestisce e si lancia una flotta di droni autonomi per ricognizione e manutenzione.";
            }
            else if (nomeStanza == "Archivio di Memoria Cristallina")
            {
                return "Un caveau sicuro per il backup dei dati cruciali della missione su supporti cristallini indistruttibili.";
            }
            else if (nomeStanza == "Sala di Teletrasporto Molecolare")
            {
                return "Permette il trasferimento istantaneo di persone e oggetti su brevi o lunghe distanze.";
            }
            else if (nomeStanza == "Blocco Medico Rigenerativo")
            {
                return "Un'infermeria dotata di macchinari avanzati per la guarigione rapida e la rigenerazione tissutale.";
            }
            else if (nomeStanza == "Corridoio di Gravità Variabile")
            {
                return "Un passaggio che può simulare diverse condizioni gravitazionali per l'allenamento o la necessità della missione.";
            }
            else if (nomeStanza == "Simulatore Ambientale Totale")
            {
                return "Una stanza versatile per l'addestramento che replica qualsiasi clima e scenario planetario.";
            }
            else if (nomeStanza == "Cupola Stellare Panoramica")
            {
                return "Offre una vista a 360 gradi dello spazio, ideale per l'osservazione e il relax.";
            }
            else if (nomeStanza == "Sala dei Reattori Antimateria")
            {
                return "Dove si produce l'energia primaria della nave attraverso reazioni di annichilazione controllata.";
            }
            else if (nomeStanza == "Centro di Comunicazione Tachionica")
            {
                return "Utilizzato per inviare e ricevere messaggi istantanei su distanze cosmiche.";
            }
            else if (nomeStanza == "Quartieri dell’Equipaggio Modulari")
            {
                return "Alloggi flessibili che possono essere riconfigurati in base alle esigenze e al numero dell'equipaggio.";
            }
            else if (nomeStanza == "Santuario del Silenzio Cosmico")
            {
                return "Una stanza di meditazione e isolamento acustico per la pace interiore.";
            }
            else if (nomeStanza == "Hangar Multifase")
            {
                return "Un vasto spazio per l'attracco e la manutenzione di navette, caccia e veicoli ausiliari.";
            }
            else
            {
                return "Descrizione non disponibile per questa stanza.";
            }
        }



        static void Main(string[] args)
        {
            string personaggio = "", stanza = "";

            int sceltapersonaggio = 0, equipaggio = 3;
            bool scassaP = false, armaletale = false, curatore = false, cacciatore = false, porteAPP = false;
            bool morto = false, scappato = false, alienomorto = false;
            //introduzione al gioco

            Console.WriteLine("La USCSS Covenant intercetta un misterioso segnale proveniente da un pianeta nascosto in una nebulosa. Oram, insieme a Daniels, Tennessee e Walter, scende a indagare.In una struttura aliena trovano delle uova. Oram ne osserva una da vicino… e un Facehugger gli balza sul volto.L’equipaggio corre alla nave e decolla in fretta, ma nella fuga la Covenant impatta contro una cintura di asteroidi. Le luci tremano, gli allarmi urlano.Nella sala medica, il corpo di Oram comincia a contorcersi. Qualcosa sta per nascere.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Benvenuto in Alien comenant la minaccia ");
            Console.WriteLine("in questo gioco dovrai raggiundere le varie stanze per trovare oggetti utili");
            Console.WriteLine("Se farai troppo rumore lo xenomorfo ti troverà e porra fine alle tue sofferenze");
            Console.WriteLine("Piano piano nel gioco dovrai sceglere dove andare ma solo se avrai la chiave, fai il percorso più corto possibile a mantieni al meglio l'equipaggio vivo");
            Console.WriteLine("non ti resta che scegliere il personaggio e giocare!");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("1. Tenente Mira Solenz\r\nRuolo: Pilota\r\n\r\n\r\nAbilità: Velocità, accesso a porte bloccate nei settori di comando\r\n\r\n\r\nCarattere: Fredda, razionale\r\n\r\n\r\nPunto debole: Bassa resistenza fisica");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("2. Dottor Elias Vern\r\nRuolo: Medico di bordo\r\n\r\n\r\nAbilità: Cura ferite, analisi biologiche rapide\r\n\r\n\r\nCarattere: Empatico, ma ansioso\r\n\r\n\r\nPunto debole: L’emotività può rallentarlo nelle decisioni");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("3. Ingegnere Karla Rens\r\nRuolo: Meccanica e manutenzione\r\n\r\n\r\nAbilità: Riparare sistemi, creare trappole contro l’alieno\r\n\r\n\r\nCarattere: Coraggiosa e determinata\r\n\r\n\r\nPunto debole: Rumorosa nei movimenti\r\n\r\n\r\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("4. Sergente Drax Morrow\r\nRuolo: Sicurezza\r\n\r\n\r\nAbilità: Forza fisica, uso di armi non letali\r\n\r\n\r\nCarattere: Protettivo, impulsivo\r\n\r\n\r\nPunto debole: L’impulsività può attirare la creatura\r\n\r\n\r\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("5. Analista Taryn Wells\r\nRuolo: Esperta in comunicazioni e sistemi informatici\r\n\r\n\r\nAbilità: Hackeraggio porte, attivazione manuale navicelle\r\n\r\n\r\nCarattere: Introversa, calcolatrice\r\n\r\n\r\nPunto debole: Scarsa resistenza allo stress\r\n\r\n\r\n");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("      ___--=--------___\r\n        /. \\___\\____   _, \\_      /-\\\r\n       /. .  _______     __/=====@\r\n       \\----/  |  / \\______/      \\-/\r\n   _/         _/ o \\\r\n  / |    o   /  ___ \\\r\n / /    o\\\\ |  / O \\ /|      __-_\r\n|o|     o\\\\\\   |  \\ \\ /__--o/o___-_\r\n| |      \\\\\\-_  \\____  ----  o___-\r\n|o|       \\_ \\     /\\______-o\\_-\r\n| \\       _\\ \\  _/ / |\r\n\\o \\_   _/      __/ /\r\n \\   \\-/   _       /|_\r\n  \\_      / |   - \\  |\\\r\n    \\____/  \\ | /  \\   |\\\r\n            | o |   | \\ |\r\n            | | |    \\ | \\\r\n           / | /      \\ \\ \\\r\n         /|  \\o|\\--\\  /  o |\\--\\\r\n         \\----------' \\---------'");
            Console.WriteLine("Ombre dense avvolgono pareti di metallo organico che sembrano respirare, illuminate solo dal fioco pulsare di venature bioluminescenti.\r Un ronzio sordo vibra nell'aria gelida, suggerendo una tecnologia incomprensibile in agguato nel buio.");
            sceltapersonaggio = Convert.ToInt32(Console.ReadLine());
            if (sceltapersonaggio == 1)
            {
                Console.WriteLine("complimenti ha scelto : Tenente Mira Solenz");
                scassaP = true;//apre le porte
            }
            else if (sceltapersonaggio == 2)
            {
                Console.WriteLine("complimenti ha scelto : Dottor Elias Vern");
                curatore = true;//cura i compagni feriti
            }
            else if (sceltapersonaggio == 3)
            {
                Console.WriteLine("complimenti ha scelto : Ingegnere Karla Rens");
                cacciatore = true;//può catturare l'alieno
            }
            else if (sceltapersonaggio == 4)
            {
                Console.WriteLine("complimenti ha scelto : Sergente Drax Morrow");
                armaletale = true;//può difendere dall'alieno
            }
            else if (sceltapersonaggio == 5)
            {
                Console.WriteLine("complimenti ha scelto : Analista Taryn Wells");
                scassaP = true;//apre le porte
            }



            while (morto == false || scappato == false || alienomorto == false)

            {
                string esitoMissione = DialogoComando();
                //mostra l'esito della missione
                Console.WriteLine("\nESITO FINALE:");
                Console.WriteLine(esitoMissione);

                Console.WriteLine("Ora inizia la tua avventura!");

                Console.WriteLine("ecco il tuo equipaggiamento ");
                string equipaggiamentoattuale;
                equipaggiamentoattuale = equipaggiamento(3, "", sceltapersonaggio.ToString());
                Console.WriteLine(equipaggiamentoattuale);

                string[] stanzaAttuale = SCpercorso(scappato);
                
                Console.WriteLine("tu ora ti trovi in:" + stanzaAttuale[0]);
                Console.WriteLine("descrizione della stanza:");
                string descrizioneStanza = OttieniDescrizioneStanza(stanzaAttuale[0]);
                Console.WriteLine(descrizioneStanza);
                int lanciodado;
                lanciodado = lancioDado();
                Console.WriteLine("hai fatto un lancio di dado e hai ottenuto: " + lanciodado);

                Console.WriteLine("--------------------------------");
                int vitaGiocatore = 100;

                Console.WriteLine("Vita iniziale:" + vitaGiocatore);

                AttaccoAlieno(ref vitaGiocatore);

                Console.WriteLine("Vita dopo l'attacco: " + vitaGiocatore);


                Console.WriteLine("--------------------------------");

                Console.WriteLine("ora dovrai scegliere cosa fare");
                string scelta;

                scelta = turnoDIG("", cacciatore, curatore, scassaP, armaletale, porteAPP, 0);
                Console.WriteLine("hai scelto di: " + scelta);

                int vitaAlieno = 40;

                //richiama il combattimento
                Console.WriteLine("\nCOMBATTIMENTO CONTRO L'ALIENO:");
                vitaAlieno = AttaccoGiocatore(vitaAlieno);
                int vita = vitaGiocatore;
                int medikit = 3;

                (int nuovaVita, int medikitRimasti) = UsaOggettoCura(vita, medikit);

                AttaccoAlieno(ref vita);
                Console.WriteLine("Vita giocatore dopo l'attacco alieno: " + vita);

                vita = nuovaVita;
                medikit = medikitRimasti;
                Console.WriteLine("Vita giocatore dopo l'uso del medikit: " + vita);
                if (vitaAlieno == 0)
                {
                    Console.WriteLine("Hai sconfitto l'alieno! Complimenti, sei un eroe!");
                    alienomorto = true;
                }
                else if (vita == 0)
                {
                    Console.WriteLine("Sei stato sconfitto dall'alieno. La tua missione finisce qui.");
                    morto = true;


                }

            }
            if (scappato == true)
            {
                Console.WriteLine("Complimenti! Sei riuscito a fuggire dallo xenomorfo e a tornare alla USCSS Covenant. La tua astuzia e il tuo coraggio hanno salvato l'equipaggio e forse l'umanità stessa.");
            }
            else if (morto == true)
            {
                Console.WriteLine("Purtroppo sei stato sopraffatto dallo xenomorfo. La tua missione finisce qui, ma il tuo sacrificio non sarà dimenticato.");
                Console.WriteLine("Mentre la Terra appariva all'orizzonte, vide l'infezione aliena pulsare nelle sue vene e capì di essere diventato l'arma che avrebbe distrutto l'umanità. Con le lacrime agli occhi, deviò la rotta verso il Sole, scegliendo di bruciare nel silenzio eterno pur di proteggere la vita di chi lo aspettava a casa.");
            }
            else if (alienomorto == true)
            {
                Console.WriteLine("Hai sconfitto lo xenomorfo e salvato l'equipaggio della USCSS Covenant! La tua astuzia e il tuo coraggio hanno fatto la differenza in questa missione pericolosa.");
            }
            Console.WriteLine("Grazie per aver giocato ad Alien comenant la minaccia!");
        }
    }
}