### GIT & Github
here I will provide another CLI cheat sheet with some of the most usual and common git commands for the CLI. I'll also add eventually some new material to practice using git and github. 

## What is GIT?
Git is a version control system that allow us to keep track of every little change we do to our code. It works by whenever we decide we have reached an "milestone", for example if I am working on a website, and I finsish up the navbar, then I create a 'commit'.
A 'commit' is a version. Git will keep track of exactly how the code looked like at the time of this 'commit'. And If we need to we can backtrack and revert back to old commits. This is INCREDEBLY practical when working 
toghether with other programmers and absolutly essential! 

##What is Github?
Github is simply explained an cloudbased interface for using git. It provides a cloud interface for us to see, and access our code. Other common cloud interfaces are Gitbucket, Gitlab etc. they all do the same thing. 


# How do programmers use git?
In big projects it would be extremely hard to be productive without Git. Imagene 20 people all working on small parts of the same project. Every time someone adds something to the codebase everyone else must stop and update their own local
version to the newest or everything will brake. With Git you dont have to do this. With git each programmer can work on their own local version without being afraid of ruin it for someone else. Let me explain: 
Imagene you and I are hired to create a new website for a customer. 
The first thing we would do is to create a 'REPO'. this can be done in a coouple of different ways. Either I create a new repo in github's website and 
then clone that repo down to my local machine, OR I create the repo locally first at my local machine and THEN push it to the cloud (AKA Github). 

When I have created the repo and made sure that there is a version on the cloud (at github or gitlab, or gitbucket), then YOU can also clone that repo down to your local machine. Now you and I have a version of the code each on our computers. 
When I make changes to the code, I push it to the cloud (github), and when you make changes to the code, you ALSO push it to the cloud (github). This means that the newest version of the code is always available at the cloude. 

### Branches
A repo have branches. The default is the main branch. We as develoeprs can create new branches. Each branch is an copy of the codebase that we developers can do changes to the code base to without affecting the main branch (or any other branch then the one we are currentyl at).

### Workflows
To maintain the code and to try avoid issues there are common ways to work with git flows. The most common way is to use issues. For every task that needs to be done an issue is created. These are also sometimes refered ´to as 'tickets'. 
So for our website for example, one ticket, or issue could be: "Create navbar", and another could be "Add footer", and a third : "Add hero section" and so on. then I take on one of the issues at a time. And the most important thing: 
  We create a new branch for each issue/ticket. So for example I decide to work on the navbar ticket. I then create a new branch naming it "Adding navbar branch" or whatever,  When I finnish a ticket/issue, 
    I merge my issue branch into the main branch of the repo. Doing this adding my navbar to the rest of the website we are createing. 

## CLI Cheat sheet
Here are some common CLI commands for using Git. 

```Bash
# Initialize a new Git repository in the current directory
git init

# Rename default branch to main (if needed)
git branch -M main

# Link your local repository to a new GitHub repository
git remote add origin <repository-url>

# Push your initial commit to GitHub
git push -u origin main
```
## 2. Starting a New Project Locally
```Bash
# Initialize a new Git repository in the current directory
git init

# Rename default branch to main (if needed)
git branch -M main

# Link your local repository to a new GitHub repository
git remote add origin <repository-url>

# Push your initial commit to GitHub
git push -u origin main
```
## 3. Daily Workflow: Staging & Committing
```Bash
# View the status of modified, staged, or untracked files
git status

# View line-by-line changes in unstaged files
git diff

# Stage specific files for commit
git add <file-name>

# Stage all modified and new files
git add .

# Commit staged changes with a message
git commit -m "Add descriptive commit message"

# Stage all tracked modified files and commit in one step
git commit -am "Short description of changes"
```
## 4. Branch Management
```Bash
# List all local branches (active branch marked with *)
git branch

# List both local and remote branches
git branch -a

# Switch to an existing branch
git switch <branch-name>
# (Or legacy: git checkout <branch-name>)

# Merge changes from another branch into your active branch
git merge <branch-name>

# Delete a local branch (safely checks if merged)
git branch -d <branch-name>

# Force delete a local branch
git branch -D <branch-name>
```

## 5. Inspecting History & Changes
```Bash
# Show commit history
git log

# Show compact history (one line per commit)
git log --oneline --graph --decorate

# Show changes introduced by a specific commit
git show <commit-hash>

# See who last modified each line of a file
git blame <file-name>
```
## 6. Undoing Changes & Saving Drafts
```
# Discard uncommitted changes in a specific file
git restore <file-name>

# Unstage a file (keep local changes)
git restore --staged <file-name>

# Stash uncommitted changes away to work on something else
git stash

# Restore stashed changes and remove from stash list
git stash pop

# List all saved stashes
git stash list

# Revert a published commit safely by creating a new inverse commit
git revert <commit-hash>
```
