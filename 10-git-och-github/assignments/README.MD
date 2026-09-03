<img src="https://media.giphy.com/media/349qKnoIBHK1i/giphy.gif?cid=ecf05e47sywxajbr0z13sxg3ovtcj2f2idcaw3qmy5et08k2&rid=giphy.gif&ct=g" width="100%">

# 02 - Git and Github

**GitHub** is a platform where developers can store, manage, track, collaborate and control changes to their coding projects.
It also has social qualities in a sense as you can take part of and contribute to what other developers are working with around the world.
GitHub is mainly referred to as a "Git repository hosting service" - meaning that the logic behind what makes this all work is system is called [Git](https://git-scm.com/).

**GitHub Desktop** is an app that lets you interact with GitHub directly without having to use your command line or Web Browser.

**Git** is the tool/language/behind-the-scenes-wizardry that we use when interacting with GitHub for example. Alot of the terms we are using today are based off if it.

-   Documentation

    -   [Git](https://git-scm.com/docs)

-   Links

    -   [Hello World, Github](https://docs.github.com/en/get-started/quickstart/hello-world)
    -   [Learn about Git](https://git-scm.com/about/)
    -   [GitHub flow chart](https://guides.github.com/introduction/flow/)
    -   [Forking and pull requests](https://guides.github.com/activities/forking/)
    -   [Markdown cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)

-   Screencasts

    -   [GitHub Desktop](https://www.youtube.com/watch?v=iv8rSLsi1xo)
    -   [Version control](https://git-scm.com/video/what-is-version-control)
    -   [Markdown tutorial with examples](https://www.youtube.com/watch?v=bpdvNwvEeSE)

-   [GitHub + GitHub Desktop Basics](https://www.youtube.com/watch?v=GqNAD4XoZ6k)

> If you happen to get stuck the best thing is to ask a study buddy [help](https://www.youtube.com/watch?v=zkTf0LmDqKI)!

## Exercises

### 1. Install Git and Github

-   For Mac:
    -   `brew install git`
    -   `brew install gh`
    -   `brew install github`
    -   For Windows: use [this](https://git-scm.com/downloads) and [this](https://desktop.github.com/) and [this](https://dev.to/yadunandanbhat/how-to-install-and-setup-github-cli-586n)link
        <br />

### 2. Add personal access token (PAT)

-   Login to [github](https://github.com)

    -   Navigate to settings/Developer settings
    -   Create PAT with need permissions
    -   Name it wisely
    -   Copy and store secure, you won't see it again!
    -   <details>
            <summary>
              Hint
            </summary>
            When asked for login, use your username and PAT as password
        </details>

    <br />

### 3. Create Git repo

-   Github
    -   Go to https://github.com/new
    -   Enter a repository name and make it public.
    -   Press **Create repository**.
-   CLI
    -   Connect to Github `gh auth login`
    -   Navigate to root directory using `cd path/path/path`
    -   `git init`
    -   `gh repo create`
        <br />

### 4. Clone your repo

-   Github
    -   Either click "Code" -> "Open with Github Desktop"
-   or CLI
    -   Go to a appropriate location on your computer and run : `git clone https://github.com/<your username>/<your repo>.git`
-   Hot tip: Place all your dev files and projects in `~/dev`, you may need to create this folder: `mkdir ~/dev` - <details>
      <summary>Hint</summary>

    You can also do this in reverse order, first run git init on your computer, than create the repo on Github.

    If you do this, leave "Add a README" unticked.
    </details>
        <br />

### 5. Add files

-   Add a README.md and .gitignore
    -   Add a nice [title](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax#headings) and [gif](https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax#images) to your readme.
        <br />

### 6. Commit and push to github

-   Github Desktop

    -   First add your files to the commit.
    -   Commit the files with a describing message.
    -   Push to Github.
    -   Check files on Github.

-   CLI
    -   `git add .` add all files or `git add <filename>` add single file.
    -   `git status` check which files are changed and committed.
    -   `git commit -m "<desriptive message>"`
    -   `git push`
        <br />

### 7. `.gitignore`

-   Add a confidential.md and add that file to .gitignore
    <br />
-   Push new files to github, make sure that confidential.md is not included
    <br />

**Extra:**

-   Fork a classmates repo and add something to the README.md file. Push it to Github and create a pull request. Ask your classmate to merge the pull request.
