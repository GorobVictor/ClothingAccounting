using System.Collections.Generic;

namespace ClothingAccounting.DataBase.Model.sqlPeople {
    public class Post {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Staff> Staff { get; set; }
    }
}
