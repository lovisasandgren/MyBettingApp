var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

// Här talar vi om att index.html (eller annan default) ska användas
app.UseDefaultFiles();  // letar efter index.html, index.htm, default.html osv
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Om du inte behöver controllers kan du kommentera bort detta
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=GetAPI}/{id?}");

app.Run();
