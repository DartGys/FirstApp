import {ApplicationConfig, importProvidersFrom, isDevMode} from '@angular/core';
import { provideRouter } from '@angular/router';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { routes } from './app.routes';
import {provideHttpClient} from "@angular/common/http";
import {provideState, provideStore, StoreModule} from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import {CardListsEffects} from "./components/cardlist/store/effects";
import {cardListsFeatureKey, cardListsReducer} from "./components/cardlist/store/reducers";
import {cardFeatureKey, cardReducer} from "./components/card/store/reducers";
import {CardEffects} from "./components/card/store/effects";


export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideHttpClient(),
    provideStore({}), provideState(cardListsFeatureKey, cardListsReducer), provideState(cardFeatureKey, cardReducer),
    provideEffects(CardListsEffects, CardEffects), provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() })]
};
