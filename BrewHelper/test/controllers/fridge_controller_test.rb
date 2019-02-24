require 'test_helper'

class FridgeControllerTest < ActionDispatch::IntegrationTest
  test "should get index" do
    get fridge_index_url
    assert_response :success
  end

end
