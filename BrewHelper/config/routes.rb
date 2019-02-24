Rails.application.routes.draw do
  get 'fridge/index'
  # For details on the DSL available within this file, see http://guides.rubyonrails.org/routing.html
  resource :fridge
  root 'fridge#index'
end
