using Microsoft.EntityFrameworkCore;
using TesteMaturidadeLinkedin.DataContext;
using TesteMaturidadeLinkedin.Service.Merge;
using TesteMaturidadeLinkedin.Service.PessoaService;
using TesteMaturidadeLinkedin.Service.ResultadoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPessoaInterface,PessoaService>();
builder.Services.AddScoped<IResultadoInterface,ResultadoService>();
builder.Services.AddScoped<IMergeInterface,MergeService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options => {
    options.AddPolicy("corsPolicy",builder => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
