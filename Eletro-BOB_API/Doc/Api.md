# Documentation API Electro BOB

## Introduction

Cette documentation vise à detaillé les différentes fonctionnalité et cas d'usage de l'API electro BOB

## Classes

### ActionBasic
Permet de stocker les éléments d'une action, est utilisé dans l'échange de donées entre le front et le back

### AreaBasic
Permet de stocker les éléments d'une ARea, est utilisé dans l'échange de donées entre le front et le back

### BasicUser
Permet de stocker les éléments d'un user, est utilisé dans l'échange de donées entre le front et le back

### ReactionBasic
Permet de stocker les éléments d'une reaction, est utilisé dans l'échange de donées entre le front et le back

### ReturnedUser
Permet de stocker les éléments du user pour le renvoyer au front

## Context

### AreaContext
Context entity Framework permmetant de symboliser la base de données coté server

## Controllers

### AboutController
route : /about.json
Renvoi les donneés des différentes actions/réactions sous forme d'un fichier json

### ActionController
route : /api/action
Renvoi les différentes actions disponible

### AreaController
route : /api/user/area
Est utilisé pour récupérer, créer, modifier ou supprimer des area lié à un utilisateur

### ConnexionController
route : /api/connexion
Est utilisé pour se connecter en utilisant une requète POST
Renvoi un json web token de connexion

### PreferenceController
route : /api/user/preference
Renvoi les préférences de l'utilisateur

### ReactionController
route : /api/reaction
Renvoi les différentes reactions disponible

### RegisterController
route : /api/register
Est utilisé pour créer un nouvel utilisateur et se connecter en utilisant une requète POST
Renvoi un json web token de connexion

## Migrations

Historique des migrations de base de données

## Models

Tables de la base de données

### ActionCatalog
Réference les actions disponibles

### ActionTrigger
Action qui permet d'effectuer une reaction toute les n secondes

### ActionTriggerBitcoin
Action qui permet d'effectuer une reaction si la valeur du bitcoin descend sous/passe au dessus d'une certaine valeure

### ActionTriggerSpoify