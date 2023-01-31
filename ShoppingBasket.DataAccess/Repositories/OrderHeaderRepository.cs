using Microsoft.EntityFrameworkCore;
using ShoppingBasket.DataAccess.Data;
using ShoppingBasket.DataAccess.ViewModels;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.DataAccess.Repositories
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderHeaderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string AplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}