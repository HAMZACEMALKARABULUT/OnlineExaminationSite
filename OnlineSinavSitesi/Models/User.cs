namespace OnlineSinavSitesi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password{ get; set; }

        //oluşturualn sınavlar
        public List<Exam> CreatedExams { get; set; }

        //katılınılan sınavlar
        public List<ExamUser> TakenExams { get; set; }

        //abi tam kafamda oturmadı  ilk defa böyle tablo oluşturuyoruz ya ondan dolayı galiba bu tablo sql e geçince anlarım ben şimdi hayali olunca oturmaması normal , bir çalıltıralım ayarları yapıp bıraktım

    }
}
