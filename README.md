nantero
=======

Nantero is an example web application demonstrating how to use [Pactas IteroJS](http://www.pactas.com). It comes with a [customized signup form](http://nantero.apphb.com/) and a [self-service account page](http://nantero.apphb.com/account). Most features are implement in JavaScript, but Nantero also has a backend and receives webhooks to better demonstrate a 'real-world' scenario.

Nantero is written in JavaScript and C#, uses [NancyFX](http://nancyfx.org) as a web framework and MongoDB as a database. 

Rolling your own
----------
To create your own instance of Nantero and modify the code, we suggest you follow these steps:

 1. create a free account at [appharbor.com](http://www.appharbor.com), a low-ceremony, heroku-like PaaS provider for .NET
 2. add a free [MongoLab](http://www.mongolab.com) instance to your appharbor account
 3. clone the repo on your machine

    git clone git@github.com:Pactas/nantero.git

 4. add your appharbor instance as a remote

    git remote add apphb https://yourname@appharbor.com/nantero.git

5. make any required changes to the code, e.g. replace the default credentials with those from your Itero account

You can then push `git push apphb master` to appharbor and see your code in action at http://yourdomain.apphb.com/!

Features / Signup
-----------
 - Custom form implemented using [angularjs](http://www.angularjs.org)
 - Modified process where the user is first registered in your application and then forwarded to Pactas
 - Supports subscribing to additional components

Features / Account Page
-------
 - Shows a list of currently booked plans and components, current balance and payment method
 - Shows a list of recent invoices and allows user to download the PDFs
 - Users can up/downgrade (to authorize the change, this call goes through the backend. A direct up/downgrade from IteroJS is not supported at this time)
 - Users can change their method of payment
 - Users can cancel their contract

FAQ
---

> Can't I simply host the site on localhost?

Yes, you can, but it requires a .NET development environment (Visual Studio, should also run on mono) and MongoDB. In any case, you'd need to make sure you can somehow receive the web hooks to see it all in action which is usually tricky because it requires inbound routing.

> What's the whole point of this?

We have learned that our customers' processes and design requirements are very diverse. Many of these processes require very fine-grained control of the user interaction. Yet, meddling with the complexities of various payment service providers, recurring payments, retrograding etc. is something you most likely don't want to concern yourselves with. IteroJS is a javascript library that makes it easy to talk to Pactas Itero, various PSPs and your own service without having to worry too much about PCI-DSS compliance or cross-origin resource sharing (CORS).
