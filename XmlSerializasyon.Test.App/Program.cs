using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlSerializasyon.Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Serialization
            //Ogrenci ogr = new Ogrenci
            //{
            //    Id = 1,
            //    Name = "Soner",
            //    Surname = "Evran",
            //    BirthDate = DateTime.Now
            //};
            //Ogrenci ogr2 = new Ogrenci
            //{
            //    Id = 2,
            //    Name = "Betül",
            //    Surname = "Deniz",
            //    BirthDate = DateTime.Now
            //};
            //Ogrenci ogr3 = new Ogrenci
            //{
            //    Id = 3,
            //    Name = "Ceren",
            //    Surname = "Susuz",
            //    BirthDate = DateTime.UtcNow
            //};

            //List<Ogrenci> liste = new List<Ogrenci>
            //{
            //    ogr,ogr2,ogr3
            //};

            //FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Ogrenci>), new XmlRootAttribute { ElementName = "Ogrenciler", Namespace = "www.yazilim114.com" });

            //serializer.Serialize(fs, liste); 
            #endregion

            #region Deserialization
            //FileStream fs = new FileStream("D:\\SonerHoca\\XmlTest\\test.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Ogrenci>), new XmlRootAttribute { ElementName = "Ogrenciler", Namespace = "www.yazilim114.com" });

            //var liste = (List<Ogrenci>)serializer.Deserialize(fs);

            //foreach (var item in liste)
            //{
            //    Console.WriteLine(item.Name+" "+item.Surname);
            //}
            //Console.ReadKey(); 
            #endregion
        }
    }

    
    public class Ogrenci
    {

        private int idField;

        private string nameField;

        private string surnameField;

        private DateTime birthDateField;

        /// <remarks/>
        public int Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Surname
        {
            get
            {
                return this.surnameField;
            }
            set
            {
                this.surnameField = value;
            }
        }

        /// <remarks/>
        public DateTime BirthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }
    }


}
