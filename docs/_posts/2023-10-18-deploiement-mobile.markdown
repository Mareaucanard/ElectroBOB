---
layout: post
title:  "Déploiement mobile"
date:   2023-10-23 15:22:07 +0200
categories: Déploiement
---
# Application android

## Synchro
```bash
npx nuxi generate # Créer une nouvelle version de la webapp
npx cap sync # Synchronise les fichiers de la webapp avec le projet android
```
## Développement
Après, vous pouvez faire `npx cap open android` ou `npx cap open ios` pour ouvrir android studio ou xcode respectivement

`npx cap run android` ou `npx cap run ios` pour éxecuter l'application sur un émulateur

## Build
Afin de générer une apk, lancer le script build-app.sh ou bien utiliser le fichier gradlew dans le dossier android.