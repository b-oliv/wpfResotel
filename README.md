# Resoltel Application WPF (PROTOTYPE)
======================================

![](https://img.shields.io/badge/RESOTEL-Build-green) ![

## Contexte
-----------

Le projet consiste en un client « Desktop » qui est développé en WPF/MVVM.La base de données est partagée entre les différents postes de l’hôtel sur le LAN local. 
L'application doit pouvoir gérer toutes les réservations clientes avec toutes les options à disposition, et afficher un planning et un tableau de bord général permettant d’un seul coup d’œil de visualiser les chambres disponibles pour une date précise, sainsi qu'un historique de réservation de chaque client. 

## Fonctionnalités (80%)
------------------------

- Système d'authentification avec gestion des rôles
- Planning de réservation affichant les chambres disponibles et réservées 
- Pagination du planning (Programmation réactive)
- Reservation à partir de ce planning avec une Modal (Programmation réactive)
- CRUD Client (Programmation réactive)
- Histotique des réservations : édition / supression et recherche par client (Converter / Programmation réactive)

## Fonctionnalités non implémentées (20%)
-----------------------------------------

- Affichage de la partie restauration
- Affichage des chambres à nettoyer
- Reservation incluant le prix et les options
- export de la facture client

## Installation de la solution
-----------------------------

### Base de donnée

> App.config

L'application est configurer sur le port "3306" sur une base de donnée MySQL.
Le nom de la base de donnée est "resotel"
Concernant le Login/Password contez l'administrateur.

Veullez aussi importer le script sql que nous avons envoyé.


### Application

Production
> Lancer le fichier ProjetRESOTEL.exe

Développement
> Import/clone et lancé le sln


