# Resoltel Application WPF (PROTOTYPE)
-------------------------------------

![](https://img.shields.io/badge/RESOTEL-Build-green)

## Contexte

Le projet consiste en un client « Desktop » qui est développé en WPF/MVVM. La base de données est partagée entre les différents postes de l’hôtel sur le LAN local. 
L'application doit pouvoir gérer toutes les réservations clientes avec toutes les options à disposition, et afficher un planning et un tableau de bord général permettant d’un seul coup d’œil de visualiser les chambres disponibles pour une date précise, ainsi qu'un historique de réservation de chaque client. 

## Fonctionnalités (80%)

- Système d'authentification avec gestion des rôles
- Planning de réservation affichant les chambres disponibles et réservées 
- Pagination du planning (Programmation réactive)
- Reservation à partir de ce planning avec une Modal (Programmation réactive)
- CRUD Client (Programmation réactive)
- Histotique des réservations : édition / suppression et recherche par client (Converter / Programmation réactive)

## Fonctionnalités non implémentées (20%)

- Affichage de la partie restauration
- Affichage des chambres qui doivent être nettoyées
- Reservation incluant le prix et les options
- Un export de la facture client

## Installation de la solution

### Base de données

> App.config

L'application est configurée sur le port "3306" sur une base de données MySQL.

- Nom de la base de données : "resotel".
- Login/Password : contactez l'administrateur (présent dans le zip dropbox)

Veulilez aussi importer le script sql que nous avons envoyé dans le dropbox.


### Application

Production
> Lancer le fichier ProjetRESOTEL.exe

Développement
> Import/clone et lancer le sln


