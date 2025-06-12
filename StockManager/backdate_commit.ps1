# Backdate Single Commit Script
$Date = "2025-06-30 12:00:00"

git init
git branch -M main
git add .
$Env:GIT_AUTHOR_DATE = $Date
$Env:GIT_COMMITTER_DATE = $Date
git commit -m "Initial release"
git remote add origin https://github.com/ilyass-elh/stock-manager.git
git push --force -u origin main
