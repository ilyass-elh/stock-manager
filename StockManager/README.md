# StockManager Pro - Solution de Gestion Commerciale

> **Projet Académique / Portfolio Ingénieur**
>
> Une application de gestion de stock moderne et intuitive développée en **VB.NET**. Conçue pour répondre aux exigences des PME avec une interface utilisateur professionnelle ("Business Slate Theme").

## À propos du projet
StockManager est une solution complète permettant de gérer efficacement les flux commerciaux d'une entreprise. Contrairement aux interfaces classiques "Windows Forms", ce projet met l'accent sur une **Expérience Utilisateur (UX)** fluide :
- **Navigation SPA (Single Page Application)** : Pas de fenêtres multiples qui s'ouvrent partout.
- **Panneaux Latéraux** : Saisie des données intégrée et élégante.
- **Design Moderne** : Palette de couleurs professionnelle (Slate Blue / White).

## Fonctionnalités Clés

### 1. Tableau de Bord (Dashboard)
- Vue synthétique de l'activité.
- Indicateurs clés : Valeur du stock, nombre de produits, alertes de stock critique.

### 2. Gestion d'Inventaire
- Affichage clair via DataGrid stylisé.
- Ajout, modification et suppression de produits.
- **Alertes visuelles** pour les produits en rupture de stock.

### 3. Gestion des Commandes (Point de Vente)
- Interface "Split-View" : Liste des produits à gauche, Panier à droite.
- Ajout rapide au panier et calcul automatique du total.
- Validation des commandes avec mise à jour immédiate du stock.

### 4. Administration Complète
- **Fournisseurs** : Gestion centralisée des partenaires.
- **Utilisateurs** : Gestion des droits d'accès (Admin / User) avec panneau latéral sécurisé.

## Technologies Utilisées
- **Langage** : VB.NET (.NET Framework 4.7.2)
- **Interface** : Windows Forms (GDI+ Custom Painting)
- **Base de Données** : Microsoft SQL Server (LocalDB / Express)
- **Architecture** : ADO.NET, Programmation Orientée Objet (POO)

## Aperçu de l'interface

*L'interface utilise un système de navigation "Sidebar" moderne et des composants DataGrid personnalisés pour une lisibilité maximale.*

## Installation
1. Cloner ce dépôt :
   ```bash
   git clone https://github.com/ilyass-elh/stock-manager.git
   ```
2. Ouvrir le fichier solution `StockManager.sln` dans **Visual Studio 2019/2022**.
3. La base de données `StockDB.mdf` est incluse dans le projet (LocalDB).
4. Lancer le projet (F5).

---
## Auteurs
- Ilyass Elhani
- Houssam Belkassaoui

*Étudiants en Ingénierie - Projet Académique 2024-2025*
