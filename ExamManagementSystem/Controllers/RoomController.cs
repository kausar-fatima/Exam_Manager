using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class RoomController
    {
        private readonly AppDbContext _context;

        public RoomController()
        {
            _context = new AppDbContext();
        }

        // ⭐ Get all rooms
        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        // ⭐ Get a single room by ID
        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.FirstOrDefault(r => r.RoomId == roomId)!;
        }

        // ⭐ Add a new room
        public Room AddRoom(string roomNumber, int capacity)
        {
            var existingRoom = _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (existingRoom != null)
            {
                throw new System.Exception("Room with the same number already exists.");
            }

            var newRoom = new Room
            {
                RoomNumber = roomNumber,
                Capacity = capacity
            };

            _context.Rooms.Add(newRoom);
            _context.SaveChanges();
            return newRoom;
        }

        // ⭐ Update existing room
        public void UpdateRoom(int roomId, string newRoomNumber, int? newCapacity)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room != null)
            {
                room.RoomNumber = newRoomNumber;
                room.Capacity = newCapacity;
                _context.SaveChanges();
            }
        }

        // ⭐ Delete a room
        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
