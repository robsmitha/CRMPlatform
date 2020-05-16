import { BehaviorSubject } from 'rxjs';
import { sendRequest, b2cLoginUrl } from './api.service'

const _appUserKey = 'appUser';

const appUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem(_appUserKey)));

export const authService = {
    clearAppUser,
    setAppUser,
    testapi,
    getB2cLoginUrl,
    appUser: appUserSubject.asObservable(),
    get appUserValue() { return appUserSubject.value }
}

function setAppUser(appUser) {
    localStorage.setItem(_appUserKey, JSON.stringify(appUser));
    appUserSubject.next(appUser);
}

async function testapi () {
    return sendRequest('/weatherforecast')
}

function getB2cLoginUrl () {
    return b2cLoginUrl()
}

function clearAppUser() {
    // remove user from local storage to log user out
    localStorage.removeItem(_appUserKey);
    appUserSubject.next(null);
}