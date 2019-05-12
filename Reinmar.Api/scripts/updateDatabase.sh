if [ -z $1 ]
then
    echo "Nalezy podać parametr będący nazwą nowej migracji"
else
    (cd ../src/Reinmar.Api; dotnet ef migrations add $1 -v)
    (cd ../src/Reinmar.Api; dotnet ef database update -v)
fi