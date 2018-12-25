workflow "check dotnet , cake , docker and docker compose " {
  on = "push"
  resolves = [
    "dotnet",
    "cake build",
    "docker",
    "docker compose",
  ]
}

action "dotnet" {
  uses = "docker://iambipinpaul/dotnetdockercake:latest"
  args = "dotnet --version"
}

action "cake build" {
  uses = "docker://iambipinpaul/dotnetdockercake:latest"
  args = "dotnet cake --version"
}

action "docker" {
  uses = "docker://iambipinpaul/dotnetdockercake:latest"
  args = "docker --version"
}

action "docker compose" {
  uses = "docker://iambipinpaul/dotnetdockercake:latest"
  args = "docker-compose version"
}

workflow "run cake build" {
  on = "push"
  resolves = ["run cake build "]
}

action "run cake build " {
  uses = "docker://iambipinpaul/dotnetdockercake:latest"
  args = "dotnet cake build.cake"
  secrets = ["DOCKER_PASSWORD"]
}

workflow "docker compose action test" {
  on = "push"
  resolves = ["run docker compose"]
}

action "run docker compose" {
  uses = "docker://iambipinpaul/dotnetdockercake:latest"
  args = "docker-compose up -d --build"
}
