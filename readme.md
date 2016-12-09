## Specs
| Input                            | Output                                                | Description                                      |
|----------------------------------|-------------------------------------------------------|--------------------------------------------------|
| List<stylist>                    | {"dave, "ryan", "susan"}                              | User can see a list of all the employees         |
| "ryan"                           | "name: ryan" List<client> {"george", "anne", "frank"} | User can click on employee and see details       |
| stylists.add("cody")             | {"dave, "ryan", "susan", "cody"}                      | User can add a stylist                           |
| clients.add("josie")             | "name: ryan" List {"george", "anne", "josie"}         | User can add to client list of specific stylists |
| stylist update ryan -> pete      | "name: pete" List {"george", "anne", "frank"}         | User can update stylist details                  |
| clients update frank -> franklin | "name: ryan" List {"george", "anne", "franklin"}      | User can update client details                   |
| stylists delete cody             | {"dave, "ryan", "susan"}                              | User can delete stylist                          |
| clients delete franklin          | "name: ryan" List {"george", "anne"}                  | User can delete client                           |
