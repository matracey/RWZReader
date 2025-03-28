# Project Description

This project is aimed at creating a utility to better manage the rules in Microsoft Outlook. The rules manager for Outlook has not changed in many revisions and it is very difficult to organize a large quantity of rules.

The original, unreleased source code, posted in 2013, provided a means to manipulate the Outlook rules export file `(\*.RWZ)`. The basic process was to export the rules to a file, use the utility to organize the rules, delete the rules from Outlook, then import the modified rules export file.

In 2016, the project was revisited and the code was stabilized. This resulted in the first alpha binary release. Since version 1.0.1.0, the project’s downloadable utility allows direct reading and writing of the rules from Outlook, whether the email store is a PST file or Exchange. The primary function remains to allow the sorting of rules.

A longer-term plan is to provide a means to edit the individual rules and provide a more flexible interface for Outlook rules management. This requires reverse-engineering all the rule criteria (about 30) and rule actions (about 25).
