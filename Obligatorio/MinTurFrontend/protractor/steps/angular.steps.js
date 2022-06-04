'use strict';

var { Given } = require('cucumber');
var { When } = require('cucumber');
var { Then } = require('cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

Given(/^Entro a la pagina "([^"]*)"$/, function (url, callback) {
    browser.get(url).then(function () {
        callback();
    });
});

When(/^Registro el punto de carga$/, function (callback) {
    element(by.id('crear')).click();
    callback();
});

When('Ingreso el nombre {string} en el campo {string}',
    function (inputTextEntry, inputName) {
        browser.driver
            .findElement(by.id(inputName))
            .clear()   
        return browser.driver
            .findElement(by.id(inputName))
            .sendKeys(inputTextEntry);
    }
);

When('Hago click en la region {string}',
    function (input) {
        browser.driver
            .findElement(by.id('region'))
            .click();
        return browser.driver
            .findElement(by.id('region' + input))
            .click();
    }
);

When('Elimino el punto de carga con identificador {string}',
    function (input) {
        return browser.driver
            .findElement(by.id('cp' + input))
            .click();
    }
);

Then('Veo el mensaje {string}', async function (mensaje) {
    browser.driver.sleep(1000);
    await browser.waitForAngular().then(function () {
      expect(
        element(by.id('respuesta')).getText()
      ).to.eventually.equal(mensaje);
    });
  });

  Then('Veo que se elimino el punto de carga correctamente', async function () {
    browser.driver.sleep(1000);
    await browser.waitForAngular().then(function () {
      expect(
        element(by.id('delete')).getText()
      ).to.eventually.equal('Punto de carga eliminado correctamente');
    });
  });