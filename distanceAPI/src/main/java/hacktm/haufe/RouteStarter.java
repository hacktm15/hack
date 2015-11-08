package hacktm.haufe;

import org.apache.camel.spring.Main;

import hacktm.haufe.initial.BaseRouteBuilder;



/**
 * All the calls for inner routes are made based on the routes defined here.
 * 
 * @author HansagiF
 *
 */
public class RouteStarter extends BaseRouteBuilder {

	@Override
	public void configure() throws Exception {
		interceptFromJetty();
//		interceptToJetty();
		
		
		//http://localhost:4568/v1/users/187684
		restConfiguration().component("jetty").host("localhost").port("4567");

//		registerSchemaValidationErrorHandler();
		
		rest("/api/distanceCar").get().to("direct:getGoogleDistance");
		
		rest("/api/distanceAir").get().to("direct:getAirRoute");
		
//		rest("/priceDiesel").get().to("direct:getPriceDiesel");
		

				
	}

	public static void main(String[] args) throws Exception {
		Main.main(args);
	}

}