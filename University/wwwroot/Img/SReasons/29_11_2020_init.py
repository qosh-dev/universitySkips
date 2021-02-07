import mysql.connector

class user :
    def __init__(self,id,name,age):
        self.id = id
        self.name = name
        self.age = age

def main(query):
    result = []
    config = {
        'host': 'localhost',
        'port': 3306,
        'database': 'social',
        'user': 'root',
        'password': 'akbar9999',
        'charset': 'utf8',
        'use_unicode': True,
        'get_warnings': True,
    }
    db = mysql.connector.Connect(**config)
    cursor = db.cursor()
    cursor.execute(query)
    rows = cursor.fetchall()
    for row in rows:
        result.append({'id' : row[0], 'name' : row[1], 'age' : row[2]})
    db.close()
    return result


out = main("SELECT * FROM user")
print(out)