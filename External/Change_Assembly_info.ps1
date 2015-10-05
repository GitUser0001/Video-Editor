$file1 = SharedAssemblyInfo.txt
$file2 = res.txt

$regex = [regex]'.{27}(.{9}).+'
$replace = '...........................$1'



(get-content "$file") | Where-Object {$_ -match '^[assembly: AssemblyVersion.+'} | {$_ -Replace $regex,$replace} | Out-File 123.txt

