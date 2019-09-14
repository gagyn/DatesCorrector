# DatesCorrector

Let's suppose you have photos or videos, which have name similar to: 

*IMG_20190907_201025.jpg* / *VID_20190907_211025.mp4* / *20190907_221025.jpg*

but the attributes of the files are incorrect (e.g. you have file *IMG_20190827_161117*, but "Date modified" is set to *2019-09-01*).

What can you do? **Use this application to automatically change details of pictures to the correct ones.**

## Getting Started

- Clone this repository, 
- build the project using .NET Core,
- start the application,
- input the path of a directory with photos to correct, or the path to single photo file.

## Starting the application

You can start the application on two ways:

- by clicking on exe file, then inputing path with parameters,
- by opening from console and passing path with parameters.

## Additional parameters

```
--ask
```
Ask for every file if you want to change the date.
