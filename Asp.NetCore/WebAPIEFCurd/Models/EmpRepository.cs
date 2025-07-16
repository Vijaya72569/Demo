namespace WebAPIEFCurd.Models
{
    public class EmpRepository
    {
        private readonly EmpDbContext _db;
        public EmpRepository(EmpDbContext db)
        {
        _db = db;
        
        }
        public List<Emp> GetAll()
        {
            return _db.Emp.ToList();
        }
        public Emp? GetById(int id)
        {
            return _db.Emp.SingleOrDefault(e => e.Id == id);
        }
        public void Add(Emp emp)
        {
            _db.Emp.Add(emp);
            _db.SaveChanges();
        }

        //public void Update(Emp emp)
        //{


        //    _db.Emp.Update(emp);
        //    _db.SaveChanges();
        //}

        public void Update(Emp emp)
        {
            var existing = _db.Emp.Find(emp.Id);
            if (existing == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }

            // Manually update fields
            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Phone = emp.Phone;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var delemp= _db.Emp.Find(id);
            if (delemp != null)
            {

                _db.Emp.Remove(delemp);
                _db.SaveChanges();
            }
        }

    }
}
