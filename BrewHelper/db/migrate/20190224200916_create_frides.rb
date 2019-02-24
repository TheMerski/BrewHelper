class CreateFrides < ActiveRecord::Migration[5.2]
  def change
    create_table :frides do |t|
      t.integer :f_id
      t.string :name
      t.decimal :setTemperature

      t.timestamps
    end
  end
end
