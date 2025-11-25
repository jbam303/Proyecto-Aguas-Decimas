Manejo del proyecto AD en git

readme.md: incluir el como instalar el proyecto y de que trata

gitignore: actualmente ya configurado

flujo de trabajo
-estructura ideal 
  1 main: codigo sagrado
  2 develop: se integra todo el trabajo en equipo. Pre-producción
  3 feacture/nombre-tarea: cada desarrollador crea una rama desde develop para trabajar una tarea especifica

ya nadie puede trabajar en main ni en develop

para empezar una tarea 
  -git checkout develop -> git pull->
  git checkout -b feacture/nombre-tarea
