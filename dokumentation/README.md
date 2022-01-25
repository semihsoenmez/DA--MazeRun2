# Anleitung

## Installation Ubuntu 20.04 mit LaTeX Editor
Installation von Ubuntu 20.04 Desktop LTS.

##### Installation notwendiger Pakete

~~~ bash
sudo apt install python
sudo apt install python3-pip
sudo pip3 install Pygments
sudo apt-get install -y texlive-full
~~~

##### Installation von TexStudio

~~~ bash
sudo add-apt-repository ppa:sunderme/texstudio
sudo apt update
sudo apt install texstudio
~~~

##### Konfiguration TeXstudio

Unter **Optionen - TeXstudio konfigurieren**

###### Kategorie Befehle

![image-20210825171238036](/home/ruh/.config/Typora/typora-user-images/image-20210825171238036.png)

bei PdfLaTeX zusätzlich `-shell-escape` einfügen.

###### Kategorie Erzeugen

Hier darauf achten, dass Standardcompiler `PdfLaTeX` und Standard Bibliographieprogramm `Biber` ist.

Jetzt MainDocument.tex öffnen und dieses mit `F5` compilieren. Jetzt ist erscheint das fertige pdf mit Beispieltext.

## git setup

```
git config --global user.name "Lieschen Müller"
git config --global user.email "Lieschen@mueller.com"
```

## SSH Schlüsselpaar erzeugen
Für den komfortablen sync empfiehlt es sich, den git Zugriff mit dem ssh-Protokoll vorzunehmen. Dazu ist ein Schlüsselpaar notwendig.
```
ssh-keygen
```
Dieser Schlüssel muss mit dem gitlab Account verknüpft werden. Dazu auf User - Settings - SSH Keys gehen und den Key einfügen.

## Erstelle ein gitlab Projekt auf https://gitlab.com
Hier wird dann die Dokmentation für die Diplomarbeit liegen. 

## Clonen des Repositories
Gehe in das Verzeichnis, in dem dem das Repository gespeichert werden soll (im Terminal und dann z.B. mit cd Dokumente) und clone dein gitlab Repository. 
```
git clone git@gitlab.com:lieschen/DA_Template.git
```
Lade nun die Vorlage über den Link https://gitlab.com/ruhxsi/latex_doku/-/archive/master/latex_doku-master.zip herunter 
und entpacke diese Daten in ein temporäres Verzeichnis. Gehe im CLI in dieses Verzeichnis und lösche das Verzeichnis .git von diesem Archiv. 
Verschiebe nun dieses Verzeichnis in den repo Ordner.

gib dann
```
git add .
git commit -am "init"
git push
```
ein

## Grundlegende git Befehle
```
git status
git add 
git add .
git commit am "meine commit message"
git push
git pull
git checkout branchXY

```

Das Erstellen sowie mergen eines branches lässt sich neben der Console auch im Webinterface erreichen

## Achtung
Wenn gitlab als kostenloser Service genutzt wird, gibt es keinen Rechtsanspruch für eine zuverlässige Datensicherung. 
Mir ist zwar kein Fall von Datenverlust bekannt, aber ich würde empfehlen, immer wieder einmal das ganze repo als zip-file 
zu sichern. Zudem gibt es ja immer die lokale Kopie des Repository auf jedem Rechner aller Diplomanden.

## Wichtige Dateien für die Dokumentation

`team_members.tex` ... hier stehen allgemeine Daten für die Dokumentation (Ersteller, Datum, etc.)

`bibliography.bib` ... verwendete Literatur

