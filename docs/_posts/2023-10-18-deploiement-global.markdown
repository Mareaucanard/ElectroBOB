---
layout: post
title:  "Déploiement global"
date:   2023-10-23 15:22:07 +0200
categories: Déploiement
---

<h2>Guide de déploiement:</h2>
  <h3>Sur système unix:</h3>
  <h4>Dépendances:</h4>
  <li>Git (outre autre manière de récupérer le code source)</li>
  <li>Docker</li>
  <br>
  <h4>Déploiement:</h4>
  {% highlight bash %}
  git clone https://github.com/Mareaucanard/ElectroBOB.git
  cd ElectroBOB
  docker-compose up
  {% endhighlight %}
  C'est tout!
  (le téléchargement des images peut prendre un certain temps et les serveurs ont tendance à etre capricieux, si vous
  rencontrez des problèmes, n'hésitez pas à relancer la commande)
