﻿using Microsoft.EntityFrameworkCore;
using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await _context.Orders.Include(o => o.Items).ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) =>
        await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

    public async Task AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}
