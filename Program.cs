using Microsoft.EntityFrameworkCore;
using QuanLySanPham.Data;
using QuanLySanPham.Repositories.Interfaces;
using QuanLySanPham.Repositories.Implementation;
using QuanLySanPham.Services;

var builder = WebApplication.CreateBuilder(args);

// ====== Đăng ký DbContext ======
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ====== Đăng ký DI cho Repository và Service ======
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// ====== Thêm MVC ======
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ====== Cấu hình pipeline ======
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// ====== Định tuyến mặc định ======
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"); // ← đổi mặc định sang Products

app.Run();
