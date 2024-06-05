using Models;
using Repositories;

/*
Payment payment = new Payment
{
    PaymentSlip = new PaymentSlip
    {
        Number = 55,
        DueDate = DateTime.Now
    },
    PaidAt = DateTime.Now,
};

new PaymentRepository().Insert(payment);
*/

/*
Employee employee = new Employee
{
    IdentificationNumber = "00303043dd",
    BirthDate = DateTime.Today,
    Role = new Role()
    {
        Id = 2
    }
};

new EmployeeRepository().Insert(employee);
*/

/*
Client client = new Client
{
    IdentificationNumber = "3333441",
    BirthDate = DateTime.Today,
};

new ClientRepository().Insert(client);
*/

/*
Sale sale = new Sale
{
    Car = new Car
    {
        LicensePlate = "ABC1234"
    },
    SoldAt = DateTime.Now,
    Price = 5004,
    Client = new Client
    {
        IdentificationNumber = "3333441"
    },
    Employee = new Employee
    {
        IdentificationNumber = "00303043dd"
    },
    Payment = new Payment
    {
        Id = 2
    }
};

new SaleRepository().Insert(sale);
*/

/*
Purchase purchase = new Purchase
{
    Car = new Car
    {
        LicensePlate = "ABC1234"
    },
    Price = 5003,
    PurchasedAt = DateTime.Now
};

new PurchaseRepository().Insert(purchase);
*/

/*
Job job = new Job
{
    Description = "some job"
};

new JobRepository().Insert(job);
*/

CarJob carJob = new CarJob
{
    Car = new Car
    {
        LicensePlate = "ABC1234"
    },
    Job = new Job
    {
        Id = 1
    },
    Status = true
};

new CarJobRepository().Insert(carJob);