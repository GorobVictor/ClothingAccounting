using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlPeople {
    class Staff {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdPost { get; set; }
        [ForeignKey("IdPost")]
        public Post Post { get; set; }
    }
}
