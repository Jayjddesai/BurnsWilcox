// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurnsWilcoxCLP.Models
{
    public class LOBEntity
    {
        #region Fields

        [Required]
        public string PolicyNumber { get; set; }
        [Required]
        public int LOBId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int StateId { get; set; }

        #endregion

        #region Methods

        public static List<ListModel> GetLOBList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "LOB1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "LOB2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "LOB3"
                },
            };
        }

        public static List<ListModel> GetProductList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "Product1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "Product2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "Product3"
                },
            };
        }

        public static List<ListModel> GetStateList()
        {
            return new List<ListModel>
            {
                new ListModel
                {
                    Id = 1,
                    Name = "State1"
                },
                new ListModel
                {
                    Id = 2,
                    Name = "State2"
                },
                new ListModel
                {
                    Id = 3,
                    Name = "State3"
                },
            };
        }

        #endregion
    }

    public class ListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
