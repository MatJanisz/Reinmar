import { RouterModule, Routes } from '@angular/router';

import { ModuleWithProviders } from '@angular/core';

import { AddPackageComponent} from './add-package/add-package.component';
import { TrackPackageComponent } from './track-package/track-package.component';
import { EditPackageComponent } from './edit-package/edit-package.component';


const routes: Routes = [
  { path: '', redirectTo: 'track-package', pathMatch: 'full' },
  { path: 'track-package', component: TrackPackageComponent },
  { path: 'add-package', component:  AddPackageComponent},
  { path: 'edit-package', component:  EditPackageComponent}
];

export const routingModule: ModuleWithProviders = RouterModule.forRoot(routes);

