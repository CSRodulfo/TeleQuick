import { Injectable } from '@angular/core';

@Injectable()
export class GlobalResources {
  deleteWarning: string = 'Esta seguro que desea eliminar ';
  deleteDeleting: string = 'Eliminando... ';
  deleteError: string = 'Error al eliminar: ';
  deleteErrorDetail: string = 'Ha ocurrido un error al eliminar \r\nError: ';

  loadError: string = 'Error cargando';
  loadErrorDetail: string = 'No se puedo recibir informacion \r\nErrors: ';

  saveValidationError: string = 'Error de validación'; 
  saveValidationErrorDetail: string = 'Por favor complete todos los campos';
  saveSaving: string = 'Grabando cambios ...';
  
  saveSucces: string = 'Creado!';
  saveSuccesDetail: string = 'Se ha creado de forma exitosa ';
  saveError: string = 'Error al crear: ';
  saveErrorDetail: string = 'Ha ocurrido un error al crear \r\nError: ';

  updateSucces: string = 'Actualizado!';
  updateSuccesDetail: string = 'Se ha actualizado de forma exitosa ';
  updateError: string = 'Error al actualizar: ';
  updateErrorDetail: string = 'Ha ocurrido un error al actualizar \r\nError: ';

}