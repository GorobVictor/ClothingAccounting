﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingAccounting.DataBase.Model.sqlPeople {
    public class Staff {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdPost { get; set; }
        [ForeignKey("IdPost")]
        public virtual Post Post { get; set; }
    }
}
