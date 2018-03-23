# Management
Hotel Management project
Në programin Menaxhimi i Hotelit kemi krijuar këto klas: klasën bazë (prind) ContactClass që ka klasët fëmijë klasën Room, ConfRoom dhe klasën statike Factory. Prej klasës Room kemi krijuar edhe dy klasët fëmijë të saj që janë: RoomEven dhe RoomOdd me anë të së cilave e kemi përmbushur edhe kërkesën tjetër që ka qenë të bëjm 3 nivele të inheritances. Gjithashtu kemi krijuar edhe klasën abstrakte Personi e cila është klasa bazë e klasës Menaxheri dhe klasës Abstrakte Punetori. Nga klasa abstrakte Punetori kemi inherituar klasat RecepsionistiDiten dhe RecepsionstiNaten. Pra gjithsej kemi krijuar 11 klasa.
Njëra nga këkesat e projektit ka qenë që të implementohen 3 interfejsa, ne në projekt kemi krijuar ineterfejsat: Hoteli, Rezervimi dhe Punetoret. Interfejsat Rezervimi dhe Hoteli i kemi implementuar ne 3 klasë: në klasën ConfRoom, RoomOdd dhe RoomEven. Ndersa interfejsin Punetoret e kemi implementuar ne klaset konkrete Menaxheri, RecepsionistiDiten dhe RecepsionistiNaten.
Forma e parë që na paraqitet pasi të kyqemi në program është forma e Loginit, ku duhet futur një username dhe passëord 
në mënyrë që të na hapet forma tjetër ku bëhet menaxhimi i rezervimeve në hotel.
Në formën e dytë gjenden butonat Add, Update, Delete dhe Clear me anë të së cilave kryhen te gjitha veprimet. 
Me butonin Add mund të fusim të dhënat në database, e nëse dëshirojmë që ato të dhëna ti bëjmë update, 
pra nëse ndryshojmë numrin e telefonit atëher këtë e mundëëson ky opsion. Ndërsa dallimi ndërmjet butonit Delete dhe Clear, 
qëndron në atë se butoni Delete i fshin të dhënat nga database ndërsa butoni Clear i fshin te dhënat vetëm nga textboxatqë 
janë të paraqitura në formë.
Eshte trasheguar edhe klasa kryesore nga hierarkia e klasave, Exeption ku trashëgiminë e kemi realizuar përmes klasës
HoteliExeption ku edhe kemi plotesuar kerkesen për përdorimin e klasës Exeption.
Ne momentin qe mbyllet Aplikacioni na shfaqet messazzhi qe na tregon qe po mbyllet Aplikacioni, 
tek ky funksion e kemi implementu  Structure.
Design Paterrnat të cilët i kemi përdor janë : Lazy dhe RIP implementimin e të cilëve  gjenden tek klasa statike Factory. 
Gjithashtu edhe polimorfizmin e kemi implementuar tek klasa Factory duke e lidhur me klasën Econtact Forma tek ComboBoxi.
Enumin e kemi perdorur në formën e parë që na paraqitet kur ta hapim programin, pra në formën e Loginit, kodin të cilin
e kemi përmisuar në mënyrë që në momentin kur të kyqemi sistemi automatikisht ne baze te usernamit te dijë se cili 
nga punëtoret është kyqur në sistem,  kodi është paraqitur më poshtë:
     enum Username
        {
            Artoni,
            Albana,
            Suferina,
        };
        //Metoda e Butonit
        private void button1_Click(object sender, EventArgs e)
        {	
            String username = "Albana";
            String password = "123";
            String username1 = "Artoni";
            String passëord1 ="123";
            String username2 = "Suferina";
            String passëord2 = "123";

            Username user = Username.Albana;
            Username user1 = Username.Artoni;
            Username user2 = Username.Suferina;
            
            if (textBox1.Text == username && textBox2.Text == password) {

               if (user == Username.Albana)
                {
                    MessageBox.Show("U kyq Albana");
                }
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else if(textBox1.Text == username1 && textBox2.Text == password1)
            {
                if (user1 == Username.Artoni)
                {
                    MessageBox.Show("U kyq Artoni");
                }
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else if(textBox1.Text == username2 && textBox2.Text == password2)
            {
                if (user2 == Username.Suferina)
                {
                    MessageBox.Show("U kyq Suferina");
                }
                this.Hide();
                Econtact ec = new Econtact();
                ec.ShowDialog();
            }
            else{
                MessageBox.Show("This User Does Not Exist");
            }
        }
